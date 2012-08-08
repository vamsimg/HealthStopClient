using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Reflection;
using HealthStopClient.com.healthstop;
using HealthStopClient;


namespace HealthStopClient
{     
	class MicrosoftRMS
	{
          public static string MakeConnectionString(string location, string DBname, string user, string password)
		{
			return String.Format("Data Source={0};Initial Catalog = {1}; User ID = {2}; Password = {3}", location, DBname, user, password);
		}	

          public static List<KeyValuePair<int, string>> GetLatestPurchaseOrders(DateTime ordersDate)
          {

               DateTime endDate = ordersDate.AddDays(1);
               var orders = new List<KeyValuePair<int, string>>();           

               // create a connection object
               SqlConnection connection = new SqlConnection(MakeConnectionString(Properties.Settings.Default.POSServerLocation,
                                                                                     Properties.Settings.Default.POSServerDBName,
                                                                                     Properties.Settings.Default.POSServerUser,
                                                                                     Properties.Settings.Default.POSServerPassword));

               // create a command object
               
               string selectQuery = @"SELECT PurchaseOrder.ID, SupplierName
                                      FROM PurchaseOrder 
                                      INNER JOIN Supplier 
                                      ON PurchaseOrder.SupplierID = Supplier.ID 
                                      WHERE DateCreated >= @ordersDate and DateCreated < @endDate AND Supplier.CustomText5 like 'healthstop_%' ";

               using (SqlCommand sqlCmd = new SqlCommand(selectQuery, connection))
               {
                    try
                    {
                         //Add SqlParameters to the SqlCommand                     
                         sqlCmd.Parameters.AddWithValue("@ordersDate", ordersDate);
                         sqlCmd.Parameters.AddWithValue("@endDate", endDate);

                         //Open the SqlConnection before executing the query.  

                         connection.Open();
                         SqlDataReader ordersDataReader = sqlCmd.ExecuteReader();

                         if (ordersDataReader.HasRows)
                         {
                              while (ordersDataReader.Read())
                              {
                                   int orderID = (int)ordersDataReader["ID"];
                                   string supplierName = (string)ordersDataReader["SupplierName"];
                                   orders.Add(new KeyValuePair<int, string>(orderID, supplierName));
                              }
                         }
                    }
                    catch
                    {
                         throw;
                    }
                    finally
                    {
                         connection.Close();
                    }
               }

               return orders;
          }


          public static List<LocalPurchaseOrder> GetSelectedPurchaseOrders(List<int> orderIDs)
          {
               List<LocalPurchaseOrder> requiredOrders = new List<LocalPurchaseOrder>();

               foreach (var orderID in orderIDs)
               {
                    requiredOrders.Add(GetPurchaseOrderByID(orderID));
               }
               return requiredOrders;
          }


          private static LocalPurchaseOrder GetPurchaseOrderByID(int orderID)
          {
                // create a connection object
               SqlConnection connection = new SqlConnection(MakeConnectionString(Properties.Settings.Default.POSServerLocation,
                                                                                     Properties.Settings.Default.POSServerDBName,
                                                                                     Properties.Settings.Default.POSServerUser,
                                                                                     Properties.Settings.Default.POSServerPassword));


               var newOrder = new LocalPurchaseOrder();   
               
               // create a command object
               
               string selectOrderQuery = @"SELECT PurchaseOrder.ID, DateCreated, RequiredDate, Supplier.CustomText5 as healthstop FROM PurchaseOrder 
                                             INNER JOIN Supplier 
                                             ON PurchaseOrder.SupplierID = Supplier.ID 
                                             WHERE PurchaseOrder.ID = @orderID  ";              

               using (SqlCommand sqlCmd = new SqlCommand(selectOrderQuery, connection))
               {                         
                    try
                    {                   
                         //Add SqlParameters to the SqlCommand                     
                         sqlCmd.Parameters.AddWithValue("@orderID", orderID);

                         //Open the SqlConnection before executing the query.  
                    
                         connection.Open();
                         SqlDataReader ordersDataReader = sqlCmd.ExecuteReader();

                         if (ordersDataReader.HasRows)
                         {
                              ordersDataReader.Read();
                             
                              newOrder.local_code = orderID.ToString();
                              newOrder.order_datetime = (DateTime)ordersDataReader["DateCreated"];
                              newOrder.due_datetime = (DateTime)ordersDataReader["RequiredDate"];                                   

                              string supplierID = (string)ordersDataReader["healthstop"];
                              
                              newOrder.supplier_id = Convert.ToInt32(supplierID.Replace("healthstop_", ""));                             
                         }
                    }
                    catch
                    {
                         throw;
                    }
                    finally
                    {
                         connection.Close();
                    }
               }

               // create a command object

               string selectOrderItemsCommandText = @"SELECT ItemLookupCode, QuantityOrdered 
                                                       FROM PurchaseOrderEntry
                                                       INNER JOIN Item                                                        
                                                       ON PurchaseOrderEntry.ItemID = Item.ID                                                      
                                                       WHERE PurchaseOrderEntry.PurchaseOrderID = @orderID";

               List<LocalPurchaseOrderItem> items = new List<LocalPurchaseOrderItem>();

               using (SqlCommand sqlCmd = new SqlCommand(selectOrderItemsCommandText, connection))
               {
                    try
                    {
                         //Add SqlParameters to the SqlCommand                     
                         sqlCmd.Parameters.AddWithValue("@orderID", orderID);
                         

                         //Open the SqlConnection before executing the query.  

                         connection.Open();
                         SqlDataReader orderItemsDataReader = sqlCmd.ExecuteReader();

                         if (orderItemsDataReader.HasRows)
                         {
                              while (orderItemsDataReader.Read())
                              {                                   
                                   var newOrderItem = new LocalPurchaseOrderItem();
                                   newOrderItem.barcode = (string)orderItemsDataReader["ItemLookupCode"];
                                   newOrderItem.quantity = (double)orderItemsDataReader["QuantityOrdered"];

                                   items.Add(newOrderItem);
                              }                              
                              newOrder.itemList = items.ToArray();                                                          
                         }
                    }
                    catch
                    {
                         throw;
                    }
                    finally
                    {
                         connection.Close();
                    }
               }
               return newOrder;
          }
     }
}

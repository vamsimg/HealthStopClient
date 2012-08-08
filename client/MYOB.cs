﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using HealthStopClient.com.healthstop;



namespace HealthStopClient
{
     public class Stock
     {
          public double stock_id;
          public double quantity;
          public decimal cost_ex;          
     }

	public class MYOB
	{         


          public static bool TestRMDBConnection(string location)
          {
               try
               {
                    OleDbConnection DBconnection = null;
                    DBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + location);

                    DBconnection.Open();
                    DBconnection.Close();
                    return true;
               }
               catch
               {
                    return false;
               }
          }

          private static int GetLastStaffID()
          {
               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               int staffID;
               try
               {
                    OleDbConnection RMDBconnection = null;

                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();

                    OleDbCommand SyncCmd = RMDBconnection.CreateCommand();
                    //Get customers.
                    string commandText = "SELECT Max(staff_id) from Staff";

                    SyncCmd.CommandText = commandText;

                    staffID = (int)SyncCmd.ExecuteScalar();

                    RMDBconnection.Close();
               }
               catch (Exception ex)
               {
                    throw;
               }               
               return staffID;
          }

          private static int GetSupplierID(string healthstopID)
          {
               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               int supplierID;
               try
               {
                    OleDbConnection RMDBconnection = null;


                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();

                    OleDbCommand selectCmd = RMDBconnection.CreateCommand();
                    //Get customers.
                    string commandText = "SELECT supplier_id from Supplier where custom2 = ?";

                    selectCmd.CommandText = commandText;
                    selectCmd.Parameters.Add("@custom2", OleDbType.VarChar).Value = healthstopID;

                    Object result = selectCmd.ExecuteScalar();
                    if (result != null)
                    {
                         supplierID = (int)result;
                    }
                    else
                    {
                         supplierID = 0;
                    }                   

                    RMDBconnection.Close();
               }
               catch (Exception ex)
               {
                    throw;
               }
               return supplierID;
          }
   


          public static List<KeyValuePair<int,string>> GetLatestPurchaseOrders(DateTime ordersDate)
          {

               DateTime endDate = ordersDate.AddDays(1);
               var orders = new List<KeyValuePair<int,string>>();


               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               OleDbConnection RMDBconnection = null;
               OleDbDataReader dbReader = null;
               RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
               RMDBconnection.Open();              

               try
               {
                    string selectOrdersCommandText = @"SELECT order_id, Supplier.supplier
                                                       FROM  Orders 
                                                       INNER JOIN Supplier
                                                       ON Orders.supplier_id = Supplier.supplier_id 
                                                       WHERE order_date >= ? and order_date < ? and Supplier.custom2 like 'healthstop_%' ";                   


                    OleDbCommand selectOrdersCmd = RMDBconnection.CreateCommand();
                    
                    selectOrdersCmd.CommandText = selectOrdersCommandText;
                    selectOrdersCmd.Parameters.Add("@order_date", OleDbType.Date).Value = ordersDate;
                    selectOrdersCmd.Parameters.Add("@end_date", OleDbType.Date).Value = endDate;

                    dbReader = selectOrdersCmd.ExecuteReader();



                    if (dbReader.HasRows)
                    {
                         while (dbReader.Read())
                         {
                              int orderID = dbReader.GetInt32(0);
                              string companyName = dbReader.GetString(1);

                             

                              orders.Add(new KeyValuePair<int,string>(orderID, companyName));                              
                         }

                    }

                    dbReader.Close();

                    
               }
               catch (Exception ex)
               {
                    throw;
               }
               finally
               {
                    RMDBconnection.Close();
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
               LocalPurchaseOrder newOrder = new LocalPurchaseOrder();
               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               OleDbConnection RMDBconnection = null;
               OleDbDataReader dbReader = null;
               RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
               RMDBconnection.Open();
               try
               {


                    string selectOrderCommandText = @"SELECT order_id, order_date, due_date, Supplier.custom2 
                                                       FROM  Orders 
                                                       INNER JOIN Supplier
                                                       ON Orders.supplier_id = Supplier.supplier_id                    
                                                       WHERE order_id = ?";






                    OleDbCommand selectOrderCmd = RMDBconnection.CreateCommand();
                    //Get customers.
                    selectOrderCmd.CommandText = selectOrderCommandText;
                    selectOrderCmd.Parameters.Add("@order_id", OleDbType.Integer).Value = orderID;

                    dbReader = selectOrderCmd.ExecuteReader();

                    if (dbReader.HasRows)
                    {
                         dbReader.Read();
                         newOrder.local_code = dbReader.GetValue(0).ToString();
                         newOrder.order_datetime = dbReader.GetDateTime(1);
                         newOrder.due_datetime = dbReader.GetDateTime(2);
                         newOrder.supplier_id = Convert.ToInt32(dbReader.GetString(3).Replace("healthstop_", ""));                             
                    }

                    dbReader.Close();



                    string selectOrderItemsCommandText = @"SELECT Stock.barcode, OrdersLine.quantity
                                                            FROM OrdersLine
                                                            INNER JOIN Stock 
                                                            ON OrdersLine.stock_id = Stock.stock_id
                                                            WHERE order_id = ? and OrdersLine.status = 0";

                    
                    List<LocalPurchaseOrderItem> items = new List<LocalPurchaseOrderItem>();

                    OleDbCommand selectItemsCmd = RMDBconnection.CreateCommand();
                    //Get customers.
                    selectItemsCmd.CommandText = selectOrderItemsCommandText;
                    selectItemsCmd.Parameters.Add("@order_id", OleDbType.Integer).Value = orderID;

                    dbReader = selectItemsCmd.ExecuteReader();

                    if (dbReader.HasRows)
                    {
                         while (dbReader.Read())
                         {
                              LocalPurchaseOrderItem newItem = new LocalPurchaseOrderItem();

                              newItem.barcode = dbReader.GetString(0);
                              newItem.quantity = dbReader.GetDouble(1);

                              items.Add(newItem);
                         }
                         newOrder.itemList = items.ToArray();
                    }

                    dbReader.Close();
                   
               }
               catch (Exception ex)
               {
                    throw;
               }
               finally
               {
                    RMDBconnection.Close();
               }
               return newOrder;
          }

          private static int GetNewGoodsID()
          {
               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               int newGoodsId = 1;
               try
               {
                    OleDbConnection RMDBconnection = null;

                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();

                    OleDbCommand SyncCmd = RMDBconnection.CreateCommand();
                    //Get customers.
                    string commandText = "SELECT Max(goods_id) from Goods";

                    SyncCmd.CommandText = commandText;
                                        

                    Object result = SyncCmd.ExecuteScalar();
                    if (result != null)
                    {
                         newGoodsId = (int)result + 1;
                    }

                    RMDBconnection.Close();
               }
               catch (Exception ex)
               {
                    throw;
               }
               return newGoodsId;
          }

          private static bool GetCostingMethod()
          {
               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               bool averageCost = false;
               try
               {
                    OleDbConnection RMDBconnection = null;

                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();

                    OleDbCommand selectCmd = RMDBconnection.CreateCommand();
                    
                    string commandText = @"SELECT sysval 
                                           FROM GlobalSysInfo
                                           WHERE syskey = 'avgcost'";                 

                    selectCmd.CommandText = commandText;

                    averageCost = (string)selectCmd.ExecuteScalar() == "True" ? true : false;                    

                    RMDBconnection.Close();
               }
               catch (Exception ex)
               {
                    throw;
               }
               return averageCost;
          }
          
          private static int GetNewGoodsLineID()
          {
               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               int newGoodsLineId = 1;
               try
               {
                    OleDbConnection RMDBconnection = null;

                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();

                    OleDbCommand SyncCmd = RMDBconnection.CreateCommand();
                    //Get customers.
                    string commandText = "SELECT Max(line_id) from GoodsLine";

                    SyncCmd.CommandText = commandText;


                    Object result = SyncCmd.ExecuteScalar();
                    if (result != null)
                    {
                         newGoodsLineId = (int)result + 1;
                    }

                    RMDBconnection.Close();
               }
               catch (Exception ex)
               {
                    throw;
               }
               return newGoodsLineId;
          }

          private static Stock GetStock(string barcode)
          {
               string RMDBLocation = Properties.Settings.Default.RMDBLocation;

               Stock foundStock = null;

               try
               {
                    OleDbConnection RMDBconnection = null;
                    OleDbDataReader dbReader = null;

                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();

                    OleDbCommand selectCmd = RMDBconnection.CreateCommand();
                    //Get customers.
                    string commandText = "SELECT stock_id, sell, quantity from Stock where Barcode = ?";

                    selectCmd.CommandText = commandText;
                    selectCmd.Parameters.Add("@Barcode", OleDbType.VarChar).Value = barcode;

                    dbReader = selectCmd.ExecuteReader();

                    if (dbReader.HasRows)
                    {
                         dbReader.Read();
                  
                         foundStock = new Stock();
                         
                         foundStock.stock_id = dbReader.GetDouble(0);
                         foundStock.cost_ex = dbReader.GetDecimal(1);
                         foundStock.quantity = dbReader.GetDouble(2);
                    }
                  

                    dbReader.Close();
                    
                    RMDBconnection.Close();
               }
               catch (Exception ex)
               {
                    throw;
               }
               return foundStock;
          }

          private static void CreateNewGoodsReceived(LocalInvoice newInvoice, int newGoodsID, int staff_id,  int supplier_id, int order_id)
          {
               decimal subtotal_ex = CalculateSubtotalEx(newInvoice);
               decimal subtotal_inc = CalculateSubtotalInc(newInvoice);

               decimal freight_ex = newInvoice.freight_inc / 1.1M;
               decimal total_ex = subtotal_ex + freight_ex;

               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               
               try
               {
                    OleDbConnection RMDBconnection = null;


                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();

                    OleDbCommand insertCmd = RMDBconnection.CreateCommand();
                    //Get customers.
                    string commandText = @"INSERT INTO Goods (goods_id, goods_date, staff_id, supplier_id, 
                                                              invoice_no, invoice_date, order_no, order_id, 
                                                              comments, exported, subtotal_ex, subtotal_inc, 
                                                              freight_tax, freight_ex, freight_inc, total_inc, 
                                                              total_ex, expected) 
                                                       VALUES (?,?,?,?, 
                                                               ?,?,?,?,
                                                               ?,?,?,?,
                                                               ?,?,?,?,
                                                               ?,?)";
                    

                    insertCmd.CommandText = commandText;
                    insertCmd.Parameters.Add("@goods_id", OleDbType.Integer).Value = newGoodsID;
                    insertCmd.Parameters.Add("@goods_date", OleDbType.Date).Value = DateTime.Now;
                    insertCmd.Parameters.Add("@staff_id", OleDbType.Integer).Value = staff_id;
                    insertCmd.Parameters.Add("@supplier_id", OleDbType.Integer).Value = supplier_id;

                    insertCmd.Parameters.Add("@invoice_no", OleDbType.Integer).Value = newInvoice.supplier_code;
                    insertCmd.Parameters.Add("@invoice_date", OleDbType.Date).Value = newInvoice.creation_datetime;
                    insertCmd.Parameters.Add("@order_no", OleDbType.VarChar).Value = order_id.ToString();
                    insertCmd.Parameters.Add("@order_id", OleDbType.Integer).Value = order_id;

                    insertCmd.Parameters.Add("@comments", OleDbType.VarChar).Value = "Written by Healthstop POS Client";
                    insertCmd.Parameters.Add("@exported", OleDbType.Boolean).Value = false;
                    insertCmd.Parameters.Add("@subtotal_ex", OleDbType.Currency).Value = subtotal_ex;
                    insertCmd.Parameters.Add("@subtotal_inc", OleDbType.Currency).Value = subtotal_inc;

                    insertCmd.Parameters.Add("@freight_tax", OleDbType.VarChar).Value = "GST";
                    insertCmd.Parameters.Add("@freight_ex", OleDbType.Currency).Value = freight_ex;                    
                    insertCmd.Parameters.Add("@freight_inc", OleDbType.Currency).Value = newInvoice.freight_inc;                    
                    insertCmd.Parameters.Add("@total_inc", OleDbType.Currency).Value = newInvoice.total_inc;

                    insertCmd.Parameters.Add("@total_ex", OleDbType.Currency).Value = total_ex;
                    insertCmd.Parameters.Add("@expected", OleDbType.Currency).Value = newInvoice.total_inc;

                    insertCmd.ExecuteNonQuery();

                    RMDBconnection.Close();
               }
               catch (Exception ex)
               {
                    throw;
               }              
          }

          private static decimal CalculateSubtotalEx(LocalInvoice newInvoice)
          {
               return newInvoice.itemList.Sum(i => i.cost_ex * (decimal)i.quantity);
          }

          private static decimal CalculateSubtotalInc(LocalInvoice newInvoice)
          {
               return newInvoice.itemList.Sum(i=> i.isGST ? (1.1M* i.cost_ex*(decimal)i.quantity) : i.cost_ex*(decimal)i.quantity);
          }


          public static string CommitInvoice(LocalInvoice newInvoice, bool updateRRP)
          {
               string statusMesssage = "";
               
               int staffID = GetLastStaffID();
               
               int supplierID = GetSupplierID("healthstop_"+newInvoice.supplierID.ToString());

               if (supplierID == 0)
               {
                    throw new Exception("Supplier not found. Check that custom2 for this Supplier has a healthstop ID.");
               }
               else
               {
                    int newGoodsID = GetNewGoodsID();

                    bool useAverageCost = GetCostingMethod();

                    int order_id = String.IsNullOrEmpty(newInvoice.purchaseorder_code) ? 0 : Convert.ToInt32(newInvoice.purchaseorder_code);

                    CreateNewGoodsReceived(newInvoice, newGoodsID, staffID, supplierID, order_id);

                    foreach (var item in newInvoice.itemList)
                    {
                         statusMesssage += CreateNewGoodsReceivedLine(item, supplierID, newGoodsID);
                         UpdateStock(item, useAverageCost, updateRRP);
                    }
               }
               return statusMesssage;
          }
                

          private static string CreateNewGoodsReceivedLine(LocalInvoiceItem item, int supplierID, int goodsID)
          {
               string statusMessage = "";

               Stock foundStock = GetStock(item.barcode);

               if (foundStock == null)
               {
                    CreateNewStock(item, supplierID);
                    statusMessage += "New stock item created for\t"+ item.barcode + "\t" +item.description + "\r\n";
                    if (item.description.Length > 40)
                    {
                         statusMessage += "Description is too long and has been shortened.\r\n";
                    }

               }

               double stockID = GetStock(item.barcode).stock_id;

               int newLineID = GetNewGoodsLineID();

               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               try
               {
                    OleDbConnection RMDBconnection = null;

                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();


                    OleDbCommand insertCommand = RMDBconnection.CreateCommand();
                    string commandText = @"INSERT INTO GoodsLine(line_id, goods_id, stock_id, goods_tax, 
                                                                 cost_ex, cost_inc, sell, quantity)
                                                       Values(?,?,?,?,
                                                              ?,?,?,?)";

                    insertCommand.CommandText = commandText;


                    insertCommand.Parameters.Add("@line_id", OleDbType.Integer).Value = newLineID;
                    insertCommand.Parameters.Add("@goods_id", OleDbType.Integer).Value = goodsID;
                    insertCommand.Parameters.Add("@stock_id", OleDbType.Double).Value = stockID;
                    insertCommand.Parameters.Add("@goods_tax", OleDbType.VarChar).Value = item.isGST ? "GST" : "FRE";

                    insertCommand.Parameters.Add("@cost_ex", OleDbType.Currency).Value = item.cost_ex;
                    insertCommand.Parameters.Add("@cost_inc", OleDbType.Currency).Value = item.isGST ? item.cost_ex*1.1M : item.cost_ex ;
                    insertCommand.Parameters.Add("@sell", OleDbType.Currency).Value = item.RRP / 1.1M;
                    insertCommand.Parameters.Add("@quantity", OleDbType.Double).Value = item.quantity;
                    
                    insertCommand.ExecuteNonQuery();

                    RMDBconnection.Close();
               }
               catch (Exception ex)
               {
                    throw;
               }
               return statusMessage;
          }

          private static double GetNewStockID()
          {
               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               double newStockId = 1;
               try
               {
                    OleDbConnection RMDBconnection = null;

                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();

                    OleDbCommand SyncCmd = RMDBconnection.CreateCommand();
                    //Get customers.
                    string commandText = "SELECT Max(stock_id) from Stock";

                    SyncCmd.CommandText = commandText;


                    Object result = SyncCmd.ExecuteScalar();
                    if (result != null)
                    {
                         newStockId = (double)result + 1;
                    }

                    RMDBconnection.Close();
               }
               catch (Exception ex)
               {
                    throw;
               }
               return newStockId;
          }

          private static void CreateNewStock(LocalInvoiceItem item, int supplierID)
          {
               double newStockID = GetNewStockID();

               string gst = item.isGST ? "GST" : "FRE";
               DateTime now = DateTime.Now;

               string description = item.description.Length > 40 ? item.description.Substring(0, 40) : item.description;

			string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               try
               {
                    OleDbConnection RMDBconnection = null;

                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();


                    OleDbCommand insertCommand = RMDBconnection.CreateCommand();
                    string commandText = @"INSERT INTO Stock (stock_id,Barcode,description,goods_tax,cost,sales_tax,
                                                              sell, quantity,date_created, supplier_id, date_modified)
                                                       Values(?,?,?,?,?,?,
                                                              ?,?,?,?,?)"; 

                    insertCommand.CommandText = commandText;

                    insertCommand.Parameters.Add("@stock_id", OleDbType.Double).Value = newStockID;
                    insertCommand.Parameters.Add("@Barcode", OleDbType.VarChar).Value = item.barcode;
                    insertCommand.Parameters.Add("@description", OleDbType.VarChar).Value = description;                                  
                    insertCommand.Parameters.Add("@goods_tax", OleDbType.VarChar).Value = gst; 
                    insertCommand.Parameters.Add("@cost", OleDbType.Currency).Value = item.cost_ex;
                    insertCommand.Parameters.Add("@sales_tax", OleDbType.VarChar).Value = gst; 

                    insertCommand.Parameters.Add("@sell", OleDbType.Currency).Value = item.RRP/1.1M;
                    insertCommand.Parameters.Add("@quantity", OleDbType.Double).Value = item.quantity;
                    insertCommand.Parameters.Add("@date_created", OleDbType.Date).Value = now;
                    insertCommand.Parameters.Add("@supplier_id", OleDbType.Integer).Value = supplierID;
                    insertCommand.Parameters.Add("@date_modified", OleDbType.Date).Value = now;
                    
                    insertCommand.ExecuteNonQuery();

                    RMDBconnection.Close();
               }
			catch (Exception ex)
			{
				throw;
			}
          }

          private static void UpdateStock(LocalInvoiceItem item, bool useAverageCost, bool updateRRP)
          {
               DateTime now = DateTime.Now;

               Stock foundStock = GetStock(item.barcode);

               decimal cost = useAverageCost ? CalculateNewAverageCost(foundStock.quantity, foundStock.cost_ex, item.cost_ex, item.quantity) : item.cost_ex;

               decimal RRP = item.RRP / 1.1M;

               double newQuantity = item.quantity + foundStock.quantity;

               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               try
               {
                    OleDbConnection RMDBconnection = null;

                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();


                    OleDbCommand insertCommand = RMDBconnection.CreateCommand();
                    string commandTextRRPUpdate = @"UPDATE Stock 
                                                    SET cost = ? , quantity = ?, date_modified = ?, sell = ?
                                                    WHERE stock_id = ?";

                    string commandTextNoRRPUpdate = @"UPDATE Stock 
                                                    SET cost = ? , quantity = ?, date_modified = ?
                                                    WHERE stock_id = ?";



                    insertCommand.CommandText = updateRRP ? commandTextRRPUpdate : commandTextNoRRPUpdate;

                    insertCommand.Parameters.Add("@cost", OleDbType.Currency).Value = cost;
                    insertCommand.Parameters.Add("@quantity", OleDbType.Double).Value = newQuantity;
                    insertCommand.Parameters.Add("@date_modified", OleDbType.Date).Value = DateTime.Now;                    

                    if (updateRRP)
                    {
                         insertCommand.Parameters.Add("@sell", OleDbType.Currency).Value = RRP;
                         insertCommand.Parameters.Add("@stock_id", OleDbType.Double).Value = foundStock.stock_id;
                    }
                    else
                    {
                         insertCommand.Parameters.Add("@stock_id", OleDbType.Double).Value = foundStock.stock_id;
                    }


                    insertCommand.ExecuteNonQuery();

                    RMDBconnection.Close();
               }
               catch (Exception ex)
               {
                    throw;
               }
          }

          private static decimal CalculateNewAverageCost(double currentQuantity, decimal currentCost, decimal newCost, double additionalQuantity)
          {
               double totalNewQuantity = currentQuantity + additionalQuantity;
               decimal newAverageCost = (currentCost * (decimal)currentQuantity + newCost * (decimal)additionalQuantity) / (decimal)totalNewQuantity;

               return newAverageCost;
          }
	}
}

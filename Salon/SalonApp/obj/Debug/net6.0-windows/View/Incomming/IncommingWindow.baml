   M S B A M L   `   `   `  ????C  ?SalonApp, Version=2.1.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SalonApp.View.IncommingSalonApp.View.Incomming  5   	   -    'SalonApp.View.Incomming.IncommingWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:SalonApp.View.Incomming     5   	   ???#E7ECEF$??bahnschrift)?5   /     ? Title$  
Доход??5   	   $	??450??6   $	??800??6$   .??5	      ? ???#E7ECEF$??5q?6     ? ColumnDefinitions 5
   
   ?? 5      $
??600* ?6   ?? 5      $
??200* ?6    ? RowDefinitions 5   
   ?? 5      $??60 ?6   ?? 5      .+?5   
   ?? $??10q?6   $??0??6   $??0??6-   
??????? ?? CornerRadius$ 5??6M   ._?5      ?? $??Right=?6    ?? Orientation$ 
Horizontal=?65   .+?5      ?? $??17(?6   
???   ?$??Период??6=   $??Center=?6K   (  "System.Windows.Controls.DatePicker  5      $??Right=?6N   $	??Top=?6l   $	??250??6?   $??5,5,5,5q?6?      SelectedDate 6   ??  ?? Path$ CashSelectedDate? ? 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox ?? 
TargetType	 ?? Property
 ?? Value ?? StringFormat ?? RelativeSource ?? AncestorType??%?   '        ?? 5      "  6    .?5      ?? 	 ? ??
 5   "   ?? 5   &   .R?5   *   ?? ${?False??62   ??6D   ?? $ SelectedDate?$ MM/yyyy?? ??  
DatePicker5   '   5      5      5       5!      5"      5$      ?? 5%   
   $??1??6   $??10q?6   
???????$ 5??6=   ._?5&      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False??6   $??10q?6?    ?? SelectedItem 63   ?? $ SelectedIncomming???6c   ?? $ 
Incommings?   Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header$ Дата??63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   ?? $
 When?  5)      $ * 6)   $ Тип??63    6@   ?? $
 Type?  5*      $ * 6)   $ 
Сумма??63    6B   ?? $ Total?  5+      $ * 6)   $ Комментарий??63    6H   ?? $ Comment?5-      5.      ?? 50   
   $??1??6   
???????$??1??61   $??
5,10,10,10q?6A   $ 5??6U   ._?51      ?? $??5q?6   .+?52      ?? $??15(?6C   $??4q?6Q   $??Добавить??6\   ??6   ?? $ OpenAddIncomming?6\   ?? 53      $??15(?6B   $??4q?6P   $??Удалить??6[   ??6   ?? $ DeleteIncomming?6[   54      55      56      57      
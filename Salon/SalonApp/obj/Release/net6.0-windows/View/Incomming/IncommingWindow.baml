   M S B A M L   `   `   `  ???? C  ?SalonApp, Version=2.1.2.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SalonApp.View.IncommingSalonApp.View.Incomming  -    'SalonApp.View.Incomming.IncommingWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:SalonApp.View.Incomming     ???#E7ECEF$??bahnschrift)?  ? Title$  
Доход??$	??450??$	??800??.??? ???#E7ECEF$??5q? ? ColumnDefinitions ?? $
??600* ??? $
??200* ? ? RowDefinitions ?? $??60 ??? .+??? $??10q?$??0??$??0??
??????? ?? CornerRadius$ 5??._??? $??Right=? ?? Orientation$ 
Horizontal=?.+??? $??17(?
???   ?$??Период??$??Center=?(  "System.Windows.Controls.DatePicker  $??Right=?$	??Top=?$	??250??$??5,5,5,5q?   SelectedDate ??  ?? Path$ CashSelectedDate? ? 	Resources :  4System.Windows.Controls.Primitives.DatePickerTextBox ?? 
TargetType	 ?? Property
 ?? Value ?? StringFormat ?? RelativeSource ?? AncestorType??%?   '        ?? "  .??? 	 ? ??
 ?? .R??? ${?False?????? $ SelectedDate?$ MM/yyyy?? ??  
DatePicker?? $??1??$??10q?
???????$ 5??._?&   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False??$??10q? ?? SelectedItem ?? $ SelectedIncomming????? $ 
Incommings?   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$ Дата??1  +System.Windows.Controls.DataGridBoundColumn   Binding ?? $
 When?  $ * $ Тип?? ?? $
 Type?  $ * $ 
Сумма?? ?? $ Total?  $ * $ Комментарий?? ?? $ Comment??? $??1??
???????$??1??$??
5,10,10,10q?$ 5??._??? $??5q?.+??? $??15(?$??4q?$??Добавить?????? $ OpenAddIncomming??? $??15(?$??4q?$??Удалить?????? $ DeleteIncomming?
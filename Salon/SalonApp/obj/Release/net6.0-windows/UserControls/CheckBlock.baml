   M S B A M L   `   `   `  ???? C  ?SalonApp, Version=2.1.2.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Salon.UserControlsSalon.UserControls  #    Salon.UserControls.CheckBlock   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:Salon.UserControls     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  .???? 
???????.+??? $??5q?$??DemiBold"?$??25(?????   ?? Path$  Service.ServiceName?&   System.Windows.Controls.DataGrid     
IsReadOnly$
 true??   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 auto    AutoGenerateColumns$ False??$??5,15,5,5q?$	??257?? ?? SelectedItem ?? $  SelectedDuty????? $  Journals?*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ PreviewMouseDoubleClick??*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command ?? *
MBCCheck+	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Width$
 *    Header$ Мастер??1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding ?? $  Employee.FullName?  $
 * $ Наличка?? ?? $  	TotalCash?  $
 * $ Безнал?? ?? $  TotalNonCash?  $
 * $ Фиктив?? ?? $  TotalFictive?  $
 * $ Сертификат?? ?? $  TotalSertificates??? $??5q?
???????$	??0.5q?._???  ?? Orientation$ 
Horizontal=?.+??? $??2q?$??Bottom=?$??12(?$!??Итого наличка: ???? $??2q?$??12(?$
??Bold"????? $  	TotalCash??? $??2q?$??Bottom=?$??12(?$??Итого безнал: ???? $??2q?$??12(?$
??Bold"????? $  TotalNonCash??? $??2q?$??Bottom=?$??12(?$??Итого Фиктив: ???? $??2q?$??12(?$
??Bold"????? $  TotalFictive??? $??2q?$??Bottom=?$??12(?$)??#Итого сертификаты: ???? $??2q?$??12(?$
??Bold"????? $  AmountSertificate??? $??2q?$??Bottom=?$??12(?$??Итого : ???? $??2q?$??12(?$
??Bold"????? $  TotalSum?
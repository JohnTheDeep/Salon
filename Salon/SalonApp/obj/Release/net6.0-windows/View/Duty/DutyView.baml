   M S B A M L   `   `   `  ???? C  ?SalonApp, Version=2.1.2.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SalonApp.View.DutySalonApp.View.Duty  !    SalonApp.View.Duty.DutyView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:SalonApp.View.Duty     2gif"http://wpfanimatedgif.codeplex.com     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  ;	behaviors+http://schemas.microsoft.com/xaml/behaviors  $??bahnschrift)????#E7ECEF  ? Title$  
Смены??$	??450??$	??800??{???  ?? Path$ 	IsEnabled?.??? .+?? $??0q? ? ColumnDefinitions ?? $	??200 ??? $
??300* ??? $	??175 ? ? RowDefinitions ?? .+???  ?? CornerRadius$ 0?????#274C77$??1??$??0??$??0q?._??? $??5q? ?? Orientation$ Vertical=?.+??? $??Bahnschrift)?$??0,5,0,5q?$??период??
??????? ?? TextAlignment$ Center=?$??17(?&   System.Windows.Controls.Calendar  -     Name$ 	Calendar1??
???   ?
???????$??5q?*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger  	   	EventName$	 Loaded??*  $Microsoft.Xaml.Behaviors.TriggerBase
   Actions.
 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter ??  ?? ElementName$ 	Calendar1??   Command ?? $ OnLoaded??? $??Bahnschrift)?$??5q?$??17(?$??Center=?$??Bottom=?
??????????? $ EmailStatus??? 
???????$ 5??$??1??$??1??$??
10,10,5,10q?._?&   System.Windows.Controls.DataGrid  $??1??   
IsReadOnly$
 True??   AutoGenerateColumns$ False??$??10q?$??0?? ?? SelectedItem ?? $ SelectedDuty????? $ Dutys?   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	    Header$ Дата??1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding ?? $ DutyDate?  $ *	 $ 
Админ?? ?? $ User.NickName?4  .System.Windows.Controls.DataGridCheckBoxColumn  $ *	 $( "Виртуальный админ???   
IsReadOnly$
 True?? ?? $ IsVirtualAdmin?  $ *	 $ Наличка?? ?? $ 
CashPerDay?  $ *	 $ Безнал?? ?? $ NonCashPerDay??? $??1??
???????$ 5??$??
0,10,10,10q?$??2??._??? $??5,2,5,2q?.+??? $??25??$??5q?$??Открыть смену?????? $ OpenDutyCommand??? $??25??$??5,2,5,2q?$??Закрыть смену?????? $ 	CloseDuty??? $??25??$??5,2,5,2q?$"??Редактирование?????? $ EditDuty??? $??25??$??5,2,5,2q?$0??*Изменить статус админа?????? $ ChangeStatus??? $??25??$??5,2,5,2q?$??Удаление??y??? $ IsDeleteVisible????? $ 
DeleteDuty??? $??5q?? $??Stretch=?$??Stretch=?
??????? J? Opacity$	 0.7Q?y??? $ IsVisibility?.+?"  FontAwesome.WPF.ImageAwesome  $ 1Q?$??Center=?$??Center=?   Icon$ Refresh=?$??48??$??48??y??? $ IsVisibility?   Spin ?? $ 	IsVisible?
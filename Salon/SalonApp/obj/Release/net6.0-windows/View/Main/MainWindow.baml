   M S B A M L   `   `   `  ???? U  QSystem.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem   SalonApp&    Salon.View.MainWindow.MainWindow   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors 	 9System,clr-namespace:System;assembly=System.Runtime 	 2
syncfusion!http://schemas.syncfusion.com/wpf 	 0hc'https://handyorg.github.io/handycontrol 	 b
 ^SharpVectors.Converters.Wpf, Version=1.8.0.0, Culture=neutral, PublicKeyToken=b532964b8548be771svgc&http://sharpvectors.codeplex.com/svgc/ 
 Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  3i+http://schemas.microsoft.com/xaml/behaviors 	 ;	behaviors+http://schemas.microsoft.com/xaml/behaviors 	 D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019     ? WindowStartupLocation$  CenterScreen=? ? Title$ Главное окно??$	??733??$
??1500?? ? 	Resources  ?? 
TargetType ?? Property ?? Value ?? 
TargetType ??Name ?? Triggers	 P? Property
 P? Value ?? 
TargetName   sys ?? Source(  "System.Windows.HorizontalAlignment&   System.Windows.VerticalAlignment??%D  '??       '?? ?    &	      '??      ?? " ??.???  ? ??$ 15(???  ? ??$ 2q???  ? ??
 ???? ??  ? ??$	 0.5q???  ? ??$	 Top=???  ? ??$	 180????  ? ??$ 50????  ? ??$
 Left=???  ? ?? ?#f2f2f2??  ? ??
 ???? ??  ? ??$ 
Bahnscrift)???  ? ?? ?? " ??.R?? $??Panel??.+??? $ ContentSite??$??Center=?$
??Left=?$??Header??$??10,10,10,10q? P? 	 ?@??
IsSelected$

 True??. ??? $ Panel?? ? ?? ?#6096BAP? 	 ?@??
IsSelected$
 False??. ??? $ Panel?? ? ?? ?#274C77??  ? ??
 ?   ???  ? ??$ 
0 0.5 0 0 q?P? 	 ? {?$
 False??. ??? $ Panel?? ? ?? ?#274C77?? $ Panel?? ? ??
 ???????  ? ?? ??Transparent???? " ???? $ Dictionary1.xaml???? StandartListView??" ??.???  ? ?? ??SkyBlue????  ? ?? u?0.5q???  ? ?? u?2q???  ? ?? X?300Q???  ? ?? X?200Q???  ? ??  
Center=???  ? ??  
Center=?.??? $??0q?.+??? $??0q????#E7ECEF$??0q? ?? TabStripPlacement$
 Left=?$??0q? ??%d   '?       '?? )     ?? " ?.???  ? ?? ?#274C77?? " ??.???  ? ??$ Center=?.@??? ???#F2F2F2${?False??$
??auto?????? $??25,0,0,0q?.+??? $??5q?$	??100??$	??100??$??/src/kindpng_2504166.png???? $??2q?.+??? $??5,2,5,5q? ?? TextAlignment$ Center=?????  ?? Path$ SelectedSalon.SalonName???  ?? 
IsSelected$
 True??$??0,0,0,0q?????  ?? Orientation$ 
Horizontal=?.+?( 
 "SharpVectors.Converters.SvgViewbox  $??0,0,5,0q?$??15??$??15??   Source$ /src/icons/home.svg???? $??bahnschrift)?$??10,0,0,0q?$??Bottom=?$??ГЛАВНАЯ??$??20??.??? ???#E7ECEF ? RowDefinitions ?? ?? $	??150 ?.+?]? $??3??$
??auto??$??Center=?$??Center=?.+???  ? UseLayoutRounding$
 True??
??????? ?? CornerRadius$ 5??$??3,3,10,3q?$??Center=?$	??110??$??Center=? J? Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 7Q?   ShadowDepth$	 0.5Q?._??? $??5q?$	??100??.+??? $??	0,0,0,0.5q?
???   ?._??? $??bahnschrift)?$??15(?$
??Wrap=?
???   ?$
 Left=?$??5q?$"??Наличка за день???? $ 
Horizontal=?$??50??.+??? $??bahnschrift)?
???   ?$??18(?$ Center=?$??5q?$??Stretch=?$??40?????? *Duty.CashPerDay+?? $??bahnschrift)?
???   ?$??18(?$ Center=?$??5q?$	??zł??$??Right=?$??40???? $
 True??
???????$ 5??$??3,3,10,3q?$??Center=?$	??110??$??Center=?   $ 7Q?$	 0.5Q?._??? $??5q?$	??100??.+??? $??	0,0,0,0.5q?
???   ?._??? $??bahnschrift)?$??15(?$
??Wrap=?
???   ?$
 Left=?$??5q?$ ??Безнал за день???? $??50??.+??? $??bahnschrift)?$ 
Horizontal=?$??50??.+??? 
???   ?$??18(?$ Center=?$??5q?$??Stretch=?$??40?????? *Duty.NonCashPerDay+?? 
???   ?$??18(?$ Center=?$??5q?$	??zł??$??Right=?$??40???? 
???????$ 5??$??3,3,10,3q?$??Center=?$	??110??$??Center=?   $ 7Q?$	 0.5Q?._??? $??bahnschrift)?$??5q?$	??100??.+??? $??
0,0,0,0.75q?
???   ?._??? $??15(?$
??Wrap=?
???   ?$
 Left=?$??5q?$"??Прибыль за день???? $??50??y??? $ IsVis?.+??? $ 
Horizontal=?.+??? 
???   ?$??18(?$ Center=?$??5q?$??Stretch=?$??40?????? *Duty.Income+?? 
???   ?$??18(?$ Center=?$??5q?$	??zł??$??Right=?$??40???? 
???????$ 5??$??3,3,10,3q?$??Center=?$	??110??$??Center=?   $ 7Q?$	 0.5Q?._??? $??bahnschrift)?$??5q?$	??100??.+??? $
??47.5??$??
0,0,0,0.75q?
???   ?._??? $??15(?$
??Wrap=?
???   ?$
 Left=?$??4q?$*??$Сертификаты за день???? $??50??.+??? $ 
Horizontal=?.+??? 
???   ?$??18(?$ Center=?$??5q?$??Stretch=?$??40?????? *Duty.TotalSertificates+?? 
???   ?$??18(?$ Center=?$??5q?$	??zł??$??Right=?$??40???? 
???????$ 5??$??3,3,10,3q?$??Center=?$	??110??$??Center=?   $ 7Q?$	 0.5Q?._??? $??bahnschrift)?$??5q?$	??100??.+??? $
??47.5??$??
0,0,0,0.75q?
???   ?._??? $??15(?$
??Wrap=?
???   ?$
 Left=?$??4q?$$??Переводы за день???? $??50??.+??? $ 
Horizontal=?.+??? 
???   ?$??18(?$ Center=?$??5q?$??Stretch=?$??40?????? *Duty.TransfersPerDay+?? 
???   ?$??18(?$ Center=?$??5q?$	??zł??$??Right=?$??40???? 
???????$ 5??$??	20,3,10,3q?$??Center=?$	??110??$??Center=?   $ 7Q?$	 0.5Q?._??? $??bahnschrift)?$??5q?$	??100??.+??? $
??47.5??$??
0,0,0,0.75q?
???   ?._??? $??15(?$
??Wrap=?
???   ?$
 Left=?$??5q?$"??Наличка в кассе???? $??50??.+??? $ 
Horizontal=?.+??? 
???   ?$??18(?$ Center=?$??5q?$??Stretch=?$??40?????? *CurrentCashBox.amountCash+?? 
???   ?$??18(?$ Center=?$??5q?$	??zł??$??Right=?$??40???? 
???????$ 5??$??3,3,10,3q?$??Center=?$	??110??$??Center=?   $ 7Q?$	 0.5Q?._??? $??bahnschrift)?$??5q?$	??100??.+??? $
??47.5??$??
0,0,0,0.75q?
???   ?._??? $??15(?$
??Wrap=?
???   ?$
 Left=?$??5q?$#??Забрал директор???? $??50??.+??? $ 
Horizontal=?.+??? 
???   ?$??18(?$ Center=?$??5q?$??Stretch=?$??40?????? $ 
Duty.Taken??? 
???   ?$??18(?$ Center=?$??5q?$	??zł??$??Right=?$??40???? 
???????$ 5??$??3,3,10,3q?$	??110??   $ 7Q?$	 0.5Q?._??? $??bahnschrift)?$??5q?$	??100??.+??? $
??47.5??$??
0,0,0,0.75q?
???   ?._??? $??15(?$
??Wrap=?
???   ?$
 Left=?$??5q?$??Итого   безнал???? $??0,0,0,0q?$??Bottom=?$??50??.+??? $ 
Horizontal=?.+??? 
???   ?$??18(?$ Center=?$??5q?$??Stretch=?$??40??y??? $ IsVis????? *CurrentCashBox.amountNonCash+?? 
???   ?$??18(?$ Center=?$??5q?$	??zł??$??Right=?$??40???? 
???????$ 5??$??3,3,10,3q?$	??110??   $ 7Q?$	 0.5Q?._??? $??bahnschrift)?$??5q?$	??100??.+??? $
??47.5??$??
0,0,0,0.75q?
???   ?._??? $??15(?$
??Wrap=?
???   ?$
 Left=?$??5q?$#??Итого переводов???? $??50??y??? $ IsVis?.+??? $ 
Horizontal=?.+??? 
???   ?$??18(?$ Center=?$??5q?$??Stretch=?$??40?????? * CurrentCashBox.amountTransfers+?? 
???   ?$??18(?$ Center=?$??5q?$	??zł??$??Right=?$??40???? ? $	??550??$??
10,10,10,0q?$??0?????#E7ECEF ? ColumnDefinitions ?? $
??200* ??? $	??40* ? ?? .+?? 
???????$??
10,10,10,0q? ?? $
??300* ? ?? .+??? 
???????$ 5??   $ 7Q?$	 0.5Q?._??? $??10q????#E7ECEF.???? -    ??Name$ ServiceListView?????#E7ECEF$??Stretch=?$??Disabled=?$??0??$
??auto??$
??auto??$??10q????? $ ViewList????? .R??  ? Orientation$ 
Horizontal=??? $??bahnschrift)?$??2??$ Vertical=?.+??? 
???   ?$	??Top=?$??1??$??40??$
??auto??$??
10,10,10,5q????? $ DutyStat????? " ??.???  ? ?? ?? $ DutyStatusColor??? $??bahnschrift)?
???   ?$	??Top=?$??1??$??50??$
??auto??$??
10,5,10,10q????? " ??.???  ? ??
 ?   ???  ? ??$	 0.5q???  ? ??
 ???????  ? ?? ?? " ??.R??? $ 5??
???????._??? $??5q?.+??? $??Center=?$-??'Текущий пользователь???? $??Center=?$??2q?
???   ????? *LoggedUser.NickName+?? $??60??$??10,125,10,0q????#E7ECEF$??1??   $ 7Q?$	 0.5Q?._??? $??60??$??2q?
???????$??1??.+??? .+??? $??bahnschrift)?$??Bottom=?$??Услуги??$??1??$??30??$
??auto??$??5,2,5,2q????? *OpenServiceWindowCommand+?? $??bahnschrift)?$??Bottom=?$#??Активные услуги??$??1??$??30??$
??auto??$??5,2,5,2q????? *" OpenActivateServiceWindowCommand+?? $??bahnschrift)?$??Bottom=?$??Мастера??$??1??$??30??$
??auto??$??5,2,5,2q????? *$"OpenActivityEmployeesWindowCommand+?? $??bahnschrift)?$??Bottom=?$??
Смены??$??1??$??30??$
??auto??$??5,2,5,2q????? *OpenDutyWindowCommand+?? $??bahnschrift)?$??Bottom=?$??Доп продажа??$??1??$??30??$
??auto??$??5,2,5,2q????? *OpenAdditCommand+?? $??bahnschrift)?$??Bottom=?$??Обновить??$??1??$??30??$
??auto??$??5,10,5,5q????? *	UpdateC+?? $??bahnschrift)?$??5q?$??30??$??
Доход?????? $ IncommingCommand??? $??2??$??2q?$??Stretch=?.+??? $??bahnschrift)?$??Center=?$??2q?$??Напоминание??
???   ??? $??bahnschrift)?$??Stretch=?$??Center=?
???????$??2q?.@??? 
???????$??Center=?$??Center=?$	??156??$	??130??.???? $
??Wrap=????? $ TodayRemind.Message??? ???? $ 
Horizontal=?.+?  $??0,0,5,0q?$??15??$??15??$ /src/icons/check.svg???? $??bahnschrift)?$??10,0,0,0q?$??Bottom=?$??СВЕРКА??.??? .+??? $??0q?$??0q?$
 Left=?$??0q? ??%d   '?       '?? )     ?? " ?.???  ? ?? ?#274C77?? " ??.???  ? ??$ Center=?.@??? 
??????????? $ 
Horizontal=?.+??? $??
Bahnscrift)?$??SemiBold"?$??Bottom=?$??Сверка услуг??.??? $??0q?$??bahnschrift)????#E7ECEF.+?? $??10,10,10,10q????#E7ECEF ?? ?? $	??220 ? ?? $??45 ??? .+??? 
???????$ 5??$??	10,5,10,5q?._??? $ 
Horizontal=?.+??? 
???   ?$??Center=?$??10,5,5,5q?$??22(?$??Админ:???? 
???   ?$??10,5,5,5q?$??Center=?$??22(????? *$"ServiceDuty.User.Employee.FullName+?? $??2,5,5,5q?$??Center=?$??;??
???   ?$??22(??? $??10,10,10,10q?$??1??$ 5??$??0??
???????$??2??._??? -    ??Name$ 	CheckList??
???????$
??0.75q????#E7ECEF$??Disabled=?$??0??$	??9.6q????? *	ViewList2+???? .R?? $ 
Horizontal=????? " ??.???  ? ?? ??SkyBlue????  ? ?? u?0.5q???  ? ?? u?2q???  ? ?? X?800Q???  ? ?? X?350Q???  ? ??  
Center=???  ? ??  
Center=??? $ 5??$??1??
???????$??1??$??	5,10,5,10q?._??? $??5q?.+?&   System.Windows.Controls.Calendar  -     Name$ 	Calendar1??$
??auto??$??5q?   SelectedDate ?? *SelectedDate+ ?? Mode$ TwoWay=??? ???? $ 
Horizontal=?.+??? $??
Bahnscrift)?$??SemiBold"?$??Bottom=?$??Сверка допов??.??? $??Bahnschrift)????#E7ECEF.+?? $??10,10,10,10q????#E7ECEF ?? ?? $	??220 ? ?? $??45 ??? .+??? $ 5??$??1??
???????$??1??$??	5,10,5,10q?._??? $??5q?
???????.+?  -   $ 	Calendar2??$
??auto??$??5q? ?? *SelectedDate2+?? 
???????$ 5??$??	10,5,10,5q?._??? $ 
Horizontal=?.+??? 
???   ?$??Center=?$??10,5,5,5q?$??22(?$??Админ:???? 
???   ?$??10,5,5,5q?$??Center=?$??22(????? *Admin.FullName+?? $??2,5,5,5q?$??Center=?$??;??
???   ?$??22(??? $ 5??$??1??
???????$??10,10,10,110q?._?&   System.Windows.Controls.DataGrid  $??10q?$??Stretch=?    AutoGenerateColumns$  False??!   
IsReadOnly$
! True?????? *ListOfAdditional+"   Columns" 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn#   Width5	  /System.Windows.Controls.DataGridLengthConverter$# *	 $   Header$$ Клиент??1
  +System.Windows.Controls.DataGridBoundColumn% 
  Binding% ?? *
ClientName+  $# *	 $$ Наличка??% ?? *Cash+  $# *	 $$ Безнал??% ?? *	NonCash+  $# *	 $$ Сертификат??% ?? *Sertificate+  $# *	 $"$ Наличка(скидка)??% ?? *DiscountCash+  $# *	 $ $ Безнал(скидка)??% ?? *DiscountNonCash+  $# *	 $$ Фиктив??% ?? *	Fictive+?? $ 5??$??1??$??2q?$
??auto??$??Center=?$??Bottom=?._??? $ 
Horizontal=?.+??? 
???????$ 5??$??3,3,3,3q?$??Center=?$	??220??$??2q?$??Center=?._??? $??5q?$	??210??.+??? 
???   ?$ Center=?$??5q?$-??'Наличка за день (допы)???? $??50??.+??? 
???   ?$??25(?$ Center=?$??5q?$??Stretch=?$??40?????? *TotalAdditCashPerDay+?? 
???????$ 5??$??3,3,3,3q?$??Center=?$	??220??$??2q?$??Center=?._??? $??5q?$	??210??.+??? 
???   ?$ Center=?$??5q?$+??%Безнал за день (допы)???? $??50??.+??? 
???   ?$??25(?$ Center=?$??5q?$??Stretch=?$??40?????? *TotalAdditNonCashPerDay+?? 
???????$ 5??$??3,3,3,3q?$??Center=?$	??220??$??2q?$??Center=?._??? $??5q?$	??210??.+??? 
???   ?$ Center=?$??5q?$%??ЗП админу за допы???? $??50??.+??? 
???   ?$??25(?$ Center=?$??5q?$??Stretch=?$??40?????? *AdminTotalAddit+?? $y?	Collapsed=????? $ 
Horizontal=?.+??? $??Bottom=?$??Сверка смен??.??? 
???????.+?? 
???????$??10q? ?? ?? $	??220 ? ?? $??80 ??? .+??? $??10q?$ 
Horizontal=?.+??? $??Center=?$??Смена:??
???   ?$??25(??? $??10,0,0,0q?$??Center=?$??
Смена??
???   ?$??25(?? 
???????$??1??.+?  $??10q??? $ 5??$??1?????#E7ECEF$??1??$??10q?._??? $??5,5,5,2q????#E7ECEF.+?  -   $ 	Calendar3??$
??auto??$??5q??? ???? $ 
Horizontal=?.+??? $??
Bahnscrift)?$??SemiBold"?$??Bottom=?$!??Сверка зарплат??.??? ???#E7ECEF.+?? $??bahnschrift)????#E7ECEF$??10q? ?? ?? $	??220 ? ?? $??45 ??? .+??? 
???????$ 5??$??	10,5,10,5q?._??? $ 
Horizontal=?.+??? $??10,5,5,5q?$??Center=?$??Смена:??
???   ?$??22(??? $??10,5,5,5q?$??Center=?
???   ?$??22(????? $ DateStat??? $??2,5,5,5q?$??Center=?$??;??
???   ?$??22(??? $??10,5,5,5q?$??Center=?$??Админ:??
???   ?$??22(??? $??10,5,5,5q?$??Center=?
???   ?$??22(????? $% StatDuty.User.Employee.FullName??? $??2,5,5,5q?$??Center=?$??;??
???   ?$??22(??? $ 5??$??1??
???????$??1??$??	5,10,5,10q?._??? $??5,5,5,5q?
???????.+?  -   $ 	Calendar4??$
??auto??$??5q? ?? $ StatisticSelectedDate??? 
???????$ 5??$??1??$??0??$??10q?._?  $??1??$??0??$??10q?& ?? SelectedItem& ?? $ SalaryEmployee????? $ StatisticList?* 	 $Microsoft.Xaml.Behaviors.Interaction'   Triggers' + 	 %Microsoft.Xaml.Behaviors.EventTrigger  (   	EventName$( PreviewMouseDoubleClick??* 	 $Microsoft.Xaml.Behaviors.TriggerBase)   Actions.) 2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction  *   Command* ?? *SalaryDoubleClick+"   $# *	 $$ Сотрудник??% ?? $ Stat.Employee.FullName?4  .System.Windows.Controls.DataGridCheckBoxColumn  $# *	 $$ Админ???% ?? $ Stat.IsAdmin?  $# *	 $$ Начисления??% ?? $ 
Stat.Total?  $# *	 $!$ Базовая ставка??% ?? $ Stat.BaseBid?  $# *	 $8$ 2Ставка виртуального админа??% ?? $ Stat.VirtualAdminBid?  $# *	 $$ Итог дня??% ?? $ Total??? {??? $ IsEnabledEmpl????? $ 
Horizontal=?.+?  $??0,0,5,0q?$??15??$??15??$ /src/icons/settings.svg???? $??bahnschrift)?$??10,0,0,0q?$??Bottom=?$??НАСТРОЙКА??.??? ???#E7ECEF.+?? $??bahnschrift)????#E7ECEF$??10q? ?? $??45 ??? ?? $??45 ???  ?? $
??400* ??? $	??225 ?.+??? 
???????$ 5??$??	10,5,10,5q?._??? $ 
Horizontal=?.+??? 
???   ?$??1??$??Работники??$??10q?$
??auto??$??15(??? $??10q?$??1??
???????$ 5??._?  $  False??$??1??$??10q?& ?? *selectedEmployee+???? *	Employees+"   $# *	 $$ ФИО??% ?? *
FullName+  $# *	 $$ Должность??% ?? *Rank.RankName+  $# *	 $$ % с пакета??% ?? *
Ppackage+  $# *	 $$ % с допа??% ?? *Paddit+  $# *	 $$ % с фиктива??% ?? *
Pfictive+  $# *	 $$$ % с ручной работы??% ?? *
Phandjob+  $# *	 $,$ &порог минимальной зп??% ?? *EntryTreshold+  $# *	 $B$ <ставка в день если зп ниже порога??% ?? *Bid++   RowDetailsTemplate+ ?? .R?  $  False?????? *Enrollments+"   $	# 250	 $$ Услуга??% ?? *Service.ServiceName+  $	# 250	 $$ Процент??% ?? *	Percent+?? 
???????$??2??$ 5??$??	10,5,10,5q?._??? $ 
Horizontal=?.+??? 
???   ?$??2??$"??Администраторы??$??10q?$
??auto??$??15(??? $??10q?$??3??$ 5??
???????._?  $??3??$??10q?$  False??& ?? *SelectedUser+???? *Admins+"   $# *	 $$ 
Админ??% ?? *
NickName+  $# *	 $($ "Тип учетной записи??% ?? *
UserType+  $# *	 $$ ФИО??% ?? *Employee.FullName+  $# *	 $$ % с пакета??% ?? *
Ppackage+  $# *	 $$ % с допа??% ?? *Paddit+  $# *	 $ $ за вирт.админа??% ?? *VirtualAdminBid+?? $??0??$	??Top=?$??Right=?$??1??$??16(?$??5,5,10,5q????? *OpenSettingsWindowCommand+.???? .+?  $??50??$??25??$* $/src/global-settings-svgrepo-com.svg???? $ 5??
???????$??
0,10,10,10q?$??1??$??1??
???????._??? .+??? $??16(?$??5q?$??Добавить?????? *OpenAddEmployeeWindow+?? $??16(?$??5q?$ ??Редактировать?????? *OpenEditEmployeeWindow+?? $??16(?$??5q?$??Удалить?????? *DeleteEmployees+?? $ 5??
???????$??
0,10,10,10q?$??3??$??1??._??? .+??? $??16(?$??5q?$ ??Редактировать?????? *OpenEditAdminCommand+?? ???#E7ECEF
?????? $??0q?{??? $ IsEnabledEmpl????? $ 
Horizontal=?.+?  $??0,0,5,0q?$??15??$??15??$ /src/icons/salary.svg???? $??bahnschrift)?$??10,0,0,0q?$??Bottom=?$??ЗАРПЛАТА??.???  ?? $
??850* ? ?? $
??400* ?.+??? $??0q????#E7ECEF$
 Left=?$??0??$??70,-1,-70,1q? ??%3   '?       ?? " ?.???  ? ?? ?#274C77.@??? $??bahnschrift)?$??Зарплата??.??? ???#E7ECEF$??10q?.+??? $	??Top=?$	??420??$
??Left=?$??25q?$??1??$	??260??
???????$ 5??._??? $??5q?.+??? 
???   ?$??17(?$??Center=?$7??1Персонализированный отчет???? $	??250??.+??? 
???   ?$ Center=?$??Работник??$??17(?$??5q??? 
???   ?, ?? DisplayMemberPath$, FullName??$??Stretch=?$??5q?& ?? *SelectedReportEmployee+???? *ReportEmployees+?? 
???   ?$ Center=?$??Процедура??$??17(?$??5q??? 
???   ?$, ServiceType??$??Stretch=?$??5q?& ?? *SelectedReportService+???? *ReportServices+?? 
???   ?$ Center=?$??Период??$??17(?$??5q??? 
???   ?$ Center=?$??C??$??17(?$??5q?(  "System.Windows.Controls.DatePicker  
???   ?$??5q?-   SelectedDate- ?? *SelectedReportESDateIn+?? 
???   ?$ Center=?$
??По??$??17(?$??5q?  $??5q?- ?? *SelectedReportESDateOut+?? $??5q?$'??!Детализированный???. d? 	IsChecked. ?? $ 	Detalized??? $??5q?$??
Отчет??$??17(????? *ShowReportEM+?? $	??Top=?$	??420??$
??Left=?$??300,25,25,25q?$??1??$	??260??
???????$ 5??._??? $??5q?.+??? 
???   ?$??17(?$??Center=?$
??Wrap=?$F??@Персонализированный отчет (Админы)??$ Center=??? $	??250??.+??? 
???   ?$ Center=?$??Работник??$??17(?$??5q??? 
???   ?$, FullName??$??Stretch=?$??5q?& ?? *SelectedReportAdmin+???? *ReportAdmins+?? 
???   ?$ Center=?$??Период??$??17(?$??5q??? 
???   ?$ Center=?$??C??$??17(?$??5q?  
???   ?$??5q?- ?? *SelectedDateInAdminReport+?? 
???   ?$ Center=?$
??По??$??17(?$??5q?  $??5q?- ?? *SelectedDateOutAdminReport+?? $??5,49,5,5q?$??
Отчет??$??17(????? *ShowReportAdm+?? $y?Hidden=?$	??Top=?$	??400??$
??Left=?$??300,25,25,25q?$??1??$	??260?????#E7ECEF$ 5??._??? $??5q?.+??? 
???   ?$??17(?$??Center=?$7??1Персонализированный отчет???? $	??250??.+??? 
???   ?$ Center=?$??
Админ??$??17(?$??5q??? 
???   ?$, FullName??$??Stretch=?$??5q?& ?? *SelectedReportEmployee+???? *ReportEmployees+?? 
???   ?$ Center=?$??Процедура??$??17(?$??5q??? 
???   ?$, ServiceName??$??Stretch=?$??5q?& ?? *SelectedReportService+???? *ReportServices+?? 
???   ?$ Center=?$??Период??$??17(?$??5q??? 
???   ?$ Center=?$??C??$??17(?$??5q?  
???   ?$??5q?- ?? *SelectedReportESDateIn+?? 
???   ?$ Center=?$
??По??$??17(?$??5q?  $??5q?- ?? *SelectedReportESDateOut+?? $??5q?$??
Отчет??$??17(????? *ShowReportEM+?? $??bahnschrift)?$??Отчеты??.???? ???#E7ECEF$??10q?$ 
Horizontal=?.+??? $	??Top=?$??25,25,15,25q?$
??Left=?$	??420??$	??260??
???????$ 5??._??? $??5q?.+??? 
???   ?$??17(?$??Center=?$*??$Отчет по процедурам???? $	??250??$??Stretch=?.+??? 
???   ?$ Center=?$??Процедура??$??17(?$??5q??? 
???   ?$??Stretch=?$, ServiceName??$??5q?& ?? *SelectedReportSService+???? *ReportServ2+?? 
???   ?$ Center=?$??Период??$??17(?$??5q??? 
???   ?$ Center=?$??C??$??17(?$??5q?  $??5q?- ?? *SelectedReportSDateIn+?? 
???   ?$ Center=?$
??По??$??17(?$??5q?  $??5q?- ?? *SelectedReportSDateOut+?? $??5,65,5,5q?$??Bottom=?$??
Отчет??$??17(????? *ShowReportS+?? $	??420??$
??Left=?$	??Top=?$??
0,25,25,25q?$??1??$	??260??
???????$ 5??._??? $??5q?.+??? 
???   ?$??17(?$??Center=?$*??$Отчет по должностям???? $	??250??$	??380??.+??? 
???   ?$ Center=?$??Должность??$??17(?$??5q??? $??Stretch=?$, RankName??$??5q?& ?? *SelectedReportRank+???? *ReportRanks+?? 
???   ?$ Center=?$??Период??$??17(?$??5q??? 
???   ?$ Center=?$??C??$??17(?$??5q?  $??5q?- ?? *SelectedReportRankDateIn+?? 
???   ?$ Center=?$
??По??$??17(?$??5q?  $??5q?- ?? *SelectedReportRankDateOut+?? $??5,65,5,5q?$??Bottom=?$??
Отчет??$??17(????? *ShowReportRanks+?? $	??420??$
??Left=?$	??Top=?$??
0,25,25,25q?$??1??$	??260??
???????$ 5??._??? $??5q?.+??? 
???   ?$??17(?$??Center=?$??Общий отчет???? $	??250??$	??380??.+??? 
???   ?$ Center=?$??Период??$??17(?$??5q??? 
???   ?$ Center=?$??C??$??17(?$??5q?  $??5q?- ?? *MainReportDateIn+?? 
???   ?$ Center=?$
??По??$??17(?$??5q?  $??5q?- ?? *MainReportDateOut+?? $??	5,129,5,5q?$??Bottom=?$??
Отчет??$??17(????? *ShowMainReport+?? $??bahnschrift)?$??Center=?$??Stretch=?{??? $ IsEnabledEmpl????? 
?????? $ 
Horizontal=?.+?  $??0,0,5,0q?$??15??$??15??$ /src/icons/pig.svg???? $??10,0,0,0q?$??Bottom=?$??
КАССА??.??? ???#E7ECEF$??5q? ??  ?? $	??30* ??? $	??90* ?.+??? .+??? $??Касса салона??$??15(?
???   ?$ Center=?]? $??2q?$
??auto??$??Center=?$??Bottom=?.+??? 
???????$ 5??$??3,3,3,3q?$??Center=?$	??220??$??Center=?._??? $??5q?$	??210??.+??? 
???   ?$ Center=?$??5q?$!??Наличка / Доход???? .+??? $??Center=?$??Center=?$??50??$ 
Horizontal=?.+??? 
???   ?$??25(?$ Center=?$??5q?$??Stretch=?$??40?????? *CurrentCashBox.amountCash+?? 
???   ?$??25(?$ Center=?$??5q?$??/??$??Stretch=?$??40???? 
???   ?$??25(?$ Center=?$??5q?$??Stretch=?$??40?????? *CurrentIncomming+?? 
???????$ 5??$??3,3,3,3q?$??Center=?$	??220??$??2q?$??Center=?._??? $??Bottom=?$??5q?$	??210??.+??? 
???   ?$ Center=?$??5q?$??Итого безнал???? $??50??.+??? 
???   ?$??25(?$ Center=?$??5q?$??Stretch=?$??40?????? *CurrentCashBox.amountNonCash+?? 
???????$ 5??$??3,3,3,3q?$??Center=?$	??220??$??2q?$??Center=?._??? $??5q?$	??210??.+??? 
???   ?$ Center=?$??5q?$#??Итого переводов???? $??50??.+??? 
???   ?$??25(?$ Center=?$??5q?$??Stretch=?$??40?????? * CurrentCashBox.amountTransfers+?? $??Center=?$??Center=?$ 
Horizontal=?.+??? $	??150??$??5q?$??15(?$??Забрать?????? $ OpenCash??? $	??150??$??5q?$??15(?$??Удалить?????? $ 
DeleteCash??? $	??150??$??5q?$??15(?$??
Доход?????? $ IncommingCommand??? 
???????$ 5??$	??Top=?$??40??$??0??$??	5,10,5,10q?$??1??._?? 
?????? .+??? $??Center=?$
 Left=?$
??Left=?$	??100??$??5q?
???   ?$??История??$??17(??? $??Center=?$??Right=?$??Период??
???   ?$??25??$ Center=?$??	5,5,265,5q?  $??Right=?$	??Top=?$	??250??$??5,5,5,5q?- ?? $ CashSelectedDate? :  4System.Windows.Controls.Primitives.DatePickerTextBox/ ?? StringFormat0 ?? RelativeSource1 ?? AncestorType??%?   '        ?? "  .???  ? ?? ?? .R??? ${?False?????? $ SelectedDate?$/ MM/yyyy??0 ?? 1 
DatePicker?? 
???????$ 5??$??1??$??0??$??5,60,5,5q?._?  $??10q?$??1??$??0??& ?? $ SelectedCash????? $ CashBoxOperationsList?"   $# *	 $$ Дата??% ?? $
 Date?  $# *	 $$ Забрано??% ?? $ Taken?  $# *	 $$ Нал\Безнал??% ?? $
 Type?  $# *	 $$ На начало дня??% ?? $ LessIn?  $# *	 $$ После забора??% ?? $
 Less??? $??bahnschrift)?$??Center=?$??Bottom=????? $ 
Horizontal=?.+?  $??0,0,5,0q?$??15??$??15??$ /src/icons/minus.svg???? $??10,0,0,0q?$??Bottom=?$??АВАНСЫ/МИНУСЫ??.??? .+??? $??0q????#E7ECEF$
 Left=?$??0??$??1?? ??%H   '?       ?? " ?.???  ? ?? ?#274C77??  ? ??$ 0q?.@??? $??bahnschrift)?$??0q?$??Минусы??.??? $??10q????#E7ECEF ?? $
??300* ??? $	??200 ? ?? $??50 ??? .+??? 
???????$ 5??$??	10,5,10,5q?._?? 
?????? .+??? $??Center=?$
 Left=?$
??Left=?$	??100??$??5q?
???   ?$??Расходы??$??17(??? $??Center=?$??Right=?$??Период??
???   ?$??25??$ Center=?$??	5,5,265,5q?  $??Right=?$??30??$	??Top=?$	??250??$??5,5,5,5q?- ?? $ MinusSelectedDate? ??%?   '        ?? "  .???  ? ?? ?? .R??? ${?False?????? $ SelectedDate?$/ MM/yyyy??0 ?? 1 
DatePicker'   $( SelectedDateChanged??.)   * ?? $ MinusDateChanged??? $??10q?
???????$ 5??$??0??$??1??._?  $??10q?& ?? $ SelectedLess????? $ 
LessesList?"   $# *	 $$ Дата??% ?? $ Duty.DutyDate?  $# *	 $$ Наименование??% ?? $
 Name?  $# *	 $$ 
Сумма??% ?? $ Amount??? $ 5??$??1??$??1??
???????$??
5,10,10,10q?._??? $??5q?.+??? $??Добавить??$??2q????? $ AddLess??? $ ??Редактировать??$??2q?y??? *IsVis+???? $ EditLess??? $??bahnschrift)?$??Авансы?????? $
 Back?.??? ???#E7ECEF$??10q? ?? $
??300* ??? $	??200 ? ?? $??50 ??? .+??? 
???????$ 5??$??	10,5,10,5q?._?? 
?????? $	??Top=?.+??? $??Center=?$
 Left=?$
??Left=?$	??100??$??5q?
???   ?$??Авансы??$??17(??? $??Center=?$??Right=?$??Период??
???   ?$??25??$ Center=?$??	5,5,265,5q?  $??Right=?$??30??$	??Top=?$	??250??$??5,5,5,5q?- ?? $ AvSelectedDate? ??%?   '        ?? "  .???  ? ?? ?? .R??? ${?False?????? $ SelectedDate?$/ MM/yyyy??0 ?? 1 
DatePicker'   $( SelectedDateChanged??.)   * ?? $ MinusDateChanged??? $??10q?
???????$ 5??$??0??$??1??._?  $??10q?& ?? $ SelectedAvac????? $ ListA?"   $# *	 $$ Дата??% ?? $ 
WhenString?  $# *	 $$ Сотрудник??% ?? $ Employee.FullName?  $# *	 $$ 
Аванс??% ?? $ Total?  $# *	 $$ 
Штраф??% ?? $
 Fine?  $# *	 $$ С??% ?? $ DateIn?  $# *	 $
$ ПО??% ?? $ DateOut??? $ 5??$??1??$??1??
???????$??
5,10,10,10q?._??? $??5q?.+??? $??Добавить??$??2q????? $ AddAv??? $ ??Редактировать??$??2q?y??? $ IsVis????? $ EditAvac??? $??Удалить??$??2q?y??? $ IsVis????? $ 
DeleteAvac?? $??Stretch=?$??Stretch=?
???????2 J? Opacity$	2 0.7Q?y??? $ IsVisibility?.+?"  FontAwesome.WPF.ImageAwesome  $2 1Q?$??Center=?$??Center=?3   Icon$3 Refresh=?$??48??$??48??y??? $ IsVisibility?4   Spin4 ?? $ 	IsVisible??? $??Идет загрузка??$??17(?$??Center=?$??Center=?$??	0,100,0,0q?y??? $ IsVisibility?
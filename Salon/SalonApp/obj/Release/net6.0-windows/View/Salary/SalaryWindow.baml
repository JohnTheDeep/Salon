   M S B A M L   `   `   `  ???? C  ?SalonApp, Version=2.1.2.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Salon.View.SalarySalon.View.Salary  $    Salon.View.Salary.SalaryWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:Salon.View.Salary     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  ???#E7ECEF  ? Title$!  Сверка зарплат??$	??752??$	??966??.???  ? RowDefinitions  ? ColumnDefinitions ?? ?? $	??300 ?.+?? $??5q? ?? $??50 ??? $
??100* ??? $
??100* ??? $	??160 ? ?? .+??? ._??? 
??????? ?? Orientation$ 
Horizontal=?$??0??$??10q?.+??? $??5,0,0,0q?$??
Смена??$??17(??? $??5,0,0,0q?$??17(?????  ?? Path$ CurrentDuty.DutyDate? J? Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 15Q?   ShadowDepth$ 1Q??? $??10q? ?? CornerRadius$ 5??
???????$??1??   $ 15Q?$ 1Q?._?? $??2q?
???????$??1??.+??? $??16(?$??Услуги??$??10,5,5,5q?&   System.Windows.Controls.DataGrid  $??12(?$??1??$??10,30,10,10q????? $ Journals?	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 *    Header$ Услуга??1  +System.Windows.Controls.DataGridBoundColumn   Binding ?? $ Service.ServiceName?  $
 * $ Клиент?? ?? $ 
ClientName?  $
 * $ Наличка?? ?? $
 Cash?   	CellStyle ??  ?? 
TargetType*  $System.Windows.Controls.DataGridCell"  .???  ?? Property ? ?? ?? Value
 ?????  $
 * $ Безнал?? ?? $ NonCash? ?? "  .???  ? ??
 ?????  $
 * $ Перевод?? ?? $ Transfer? ?? "  .???  ? ??
 ???_?  $
 * $ Фиктив?? ?? $ Fictive? ?? "  .???  ? ??
 ??ح?  $
 * $ Сертификат?? ?? $ Sertificate? ?? "  .???  ? ??
 ??·?  $
 * $ 
Пакет?? ?? $ Package? ?? "  .???  ? ??
 ?????  $
 * $  Наличка(пакет)?? ?? $ PackageCash? ?? "  .???  ? ??
 ?????  $
 * $ Безнал(пакет)?? ?? $ PackageNonCash? ?? "  .???  ? ??
 ?????  $
 * $ Наличка(допы)?? ?? $ 	AdditCash? ?? "  .???  ? ??
 ?????  $
 * $ Безнал(допы)?? ?? $ AdditNonCash? ?? "  .???  ? ??
 ?????  $
 * $) #Наличка(руч.работа)?? ?? $ HandJobCash? ?? "  .???  ? ??
 ?????  $
 * $' !Безнал(руч.работа)?? ?? $ HandJobNonCash? ?? "  .???  ? ??
 ?????  $
 * $ Итог?? ?? $ Total?  $
 * $ Начисления?? ?? $ 	UserTotal??? $??10q?$ 5??
???????$??2??   $ 15Q?$ 1Q?._?? $??10q?
???????$??2??.+??? $??16(?$1??+Дополнительные продажи??$??10,5,5,5q?  $??12(?$??1??$??10,30,10,10q????? $ Additionals?	   $
 * $ Клиент?? ?? $ 
ClientName?  $
 * $ Наличка?? ?? $
 Cash? ?? "  .???  ? ??
 ?????  $
 * $ Безнал?? ?? $ NonCash? ?? "  .???  ? ??
 ???_?  $
 * $ Фиктив?? ?? $ Fictive? ?? "  .???  ? ??
 ???_?  $
 * $ Сертификат?? ?? $ Sertificate? ?? "  .???  ? ??
 ???_?  $
 * $" Наличка(скидка)?? ?? $ DiscountCash? ?? "  .???  ? ??
 ?????  $
 * $  Безнал(скидка)?? ?? $ DiscountNonCash? ?? "  .???  ? ??
 ???_?  $
 * $ Начисления?? ?? $ 	UserTotal??? $??3??.+??? 
???????$??1??$ 5??$??10,10,10,10q?$	??145??   $ 15Q?$ 1Q?._?? $??5q?$??Center=?$??1??.+?]? $
??auto??$??Center=?$??Center=?.+??? ???#E7ECEF$ 5??$??3,3,3,3q?$??Center=?$	??130??$??Center=?._??? $??5q?$	??120??.+??? $??15(?$
??Wrap=?
???   ? ?? TextAlignment$ Center=?$??5q?$3??-Всего отчислений(услуги)???? $??50??.+??? 
???   ?$??20(?$ Center=?$??5q?$??Stretch=?$??40?????? $ TotalIn??? ???#E7ECEF$ 5??$??10,3,3,3q?$??Center=?$	??130??$??Center=?._??? $??5q?$	??120??.+??? $??15(?$
??Wrap=?
???   ?$ Center=?$??5q?$<??6Всего отчислений(доп.продажи)???? $??50??.+??? 
???   ?$??20(?$ Center=?$??5q?$??Stretch=?$??40?????? $ TotalIn2??? ???#E7ECEF$ 5??$??10,3,3,3q?$??Center=?$	??130??$??Center=?._??? $??5q?$	??120??.+??? $??15(?$
??Wrap=?
???   ?$ Center=?$??5q?$8??2Ставка виртуального админа???? $??50??.+??? 
???   ?$??20(?$ Center=?$??5q?$??Stretch=?$??40?????? $ AdminBid??? ???#E7ECEF$ 5??$??10,3,3,3q?$??Center=?$	??130??$??Center=?._??? $	??125??$??5q?$	??120??.+??? $??15(?$
??Wrap=?
???   ?$ Center=?$??5q?$!??Базовая ставка???? $??Bottom=?$??0,40,0,0q?$??50??.+??? 
???   ?$??20(?$ Center=?$??5q?$??Stretch=?$??40?????? $	 Bid??? $ 5??$	??280??
???????$??10q?$??1??$??1??   $ 15Q?$ 1Q?._??? 
???????$??2q?$??1??$??1??.+??? 
???????$ 5??$??Center=?$	??Top=?$??5q?$	??150??$	??150??
???????._??? $??Center=?.+??? .+??? $#??/src/icons/contacts_512px.png???? $	??270??$ 5?????#E7ECEF$??Center=?$??10q?._??? $??	15,5,15,5q?.+??? $ Center=?$+??%Проценты сотрудника??$??5q??? $ 
Horizontal=?.+??? $??Сотрудник??
???   ?$??12(??? $??80,0,0,0q?
???   ?$??12(????? $ SelectedEmployee.FullName??? $ 
Horizontal=?.+??? $??% c пакета??
???   ?$??12(??? $??80,0,0,0q?
???   ?$??12(????? $ SelectedEmployee.Ppackage??? $ 
Horizontal=?.+??? $??% c допа??
???   ?$??12(??? $??90,0,0,0q?
???   ?$??12(????? $ SelectedEmployee.Paddit??? $ 
Horizontal=?.+??? $??% c фиктива??
???   ?$??12(??? $??71,0,0,0q?
???   ?$??12(????? $ SelectedEmployee.Pfictive??? $ 
Horizontal=?.+??? $#??% c ручной работы??
???   ?$??12(??? $??32,0,0,0q?
???   ?$??12(????? $ SelectedEmployee.Phandjob??? $ 
Horizontal=?.+??? $??Порог мин.зп??
???   ?$??12(??? $??64,0,0,0q?
???   ?$??12(????? $$ SelectedEmployee.EntryTreshold??? $ 
Horizontal=?.+??? $??Ставка??
???   ?$??12(??? $??	102,0,0,0q?
???   ?$??12(????? $ SelectedEmployee.Bid??? $#??Проценты админа??$ Center=?$??5q?y??? $ IsVis??? y??? $ IsVis?.+??? $ 
Horizontal=?.+??? $??% с пакета??
???   ?$??12(??? $??80,0,0,0q?
???   ?$??12(????? $ User.Ppackage??? $ 
Horizontal=?.+??? $??% с допа??
???   ?$??12(??? $??88,0,0,0q?
???   ?$??12(????? $ User.Paddit??? $ 
Horizontal=?.+??? $)??#Ставка вирт. админа??
???   ?$??12(??? $??25,0,0,0q?
???   ?$??12(????? $ SelectedEmployee.Bid?  $??10q?$	??251?????? $" SelectedEmployee.Enrollments?	   $
 * $ Услуга?? ?? $ Service.ServiceName?  $
 * $ Процент?? ?? $ Percent?
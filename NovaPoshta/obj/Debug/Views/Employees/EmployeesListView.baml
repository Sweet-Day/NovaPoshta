   M S B A M L   `   `   `  ????E  ANovaPoshta, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:NovaPoshta.Views.EmployeesNovaPoshta.Views.Employees  5      =#clr-namespace:NovaPoshta.ViewModelsNovaPoshta.ViewModels  5      2    ,NovaPoshta.Views.Employees.EmployeesListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:NovaPoshta.Views.Employees     5      2vm#clr-namespace:NovaPoshta.ViewModels     5        ? DataContext  5      2   ,NovaPoshta.ViewModels.EmployeesListViewModel  5   
   6&   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $
??0.5* ?6   6.   ?? 5      $
??0.5* ?6   6.   ?? 5      $
??0.5* ?6   6.   ?? 5      $
??0.5* ?6   6.    ? RowDefinitions 5   
   ?? 5      $	??120 ?6   6+   ?? 5      $??50 ?6   6*   ?? 5      $??60 ?6   6*   ?? 5      6   .+?5   
   ??    WhiteBorder#??[  6   $??5??66   $??4??6J   ._?5      ??  ?? Orientation$ Vertical=?6   .+?5      ]? .+?5      ?? $??Center=?6     
 Header#??[ 6;   $??32(?6[   Робітники5!      ?? 5#      $??Right=?6!   $ 
Horizontal=?6=   .+?5$      ?? $??/Resources/icons/man.png??6    $??Right=?6B   $??50??6^   6k   ?? 5%        	Paragraph#??[ 6$   $??5q?6G   ??6R   ?? *
LoggedUser+6p   5&      5'      5)      5,      ?? 5-   
     TextBoxDefaultStyle#??[ 6   $??4??5.      $??1??5/      $??30??50      $	??Top=?51      $??
30,0,125,0q?6.   ??52      ?? *SearchString+66   ?? 54   
     LightRedButton#??[ 6   $	??Top=?55      $??50??56      $??1??57      $??3??58      $??Center=?59      ??5:      ?? *SearchEmployeeCommand+.??5<      ?? $!??/Resources/icons/search.png??6   $??30??69   6F   5=      ?? 5>   
   $??0??6   $??2??6#   $	??140??60   $??30??6<    ?? Text$ Сортування??6H    ?? 
IsEditable .  ?? 
IsReadOnly .   LightComboBox#??[ 5?       ?? SelectedIndex 6:   ?? *
SortType+.@?5@      ?? -   5        $??Item1??5@   F     LightComboBoxItem#??[ 6   .??6S   За ПІБ6[   ?? 5A      -   5        $??Item2??5A   F   #??[ 6   .??6S   &$За датою народження6h   ?? 5B      -   5        $??Item3??5B   F   #??[ 6   .??6S   &$За номером телефону6h   ?? 5C      -   5        $??Item4??5C   F   #??[ 6   .??6S   (&За номером поштомата6i   5D      ?? 5E   
   #??[ 6   $??1??6`   $??2??6p   $	??140??6}   $??30??6?   ??69   ?? *AddEmployeeCommand+.??6?   Додати6?   ?? 5F   
   #??[ 6   $??2??6c   $??2??6s   $	??140??6?   $??30??6?   ??69   ?? *UpdateEmployeeCommand+.??6?   Редагувати6?   ?? 5G   
   #??[ 6   $	??140??6c   $??3??6o   $??2??6   $??30??6?   ??69   ?? *RemoveEmployeeCommand+.??6?   Видалити6?   &   System.Windows.Controls.DataGrid  5H   
   $??0??5I      $??3??5J      $??4??5K        Grid#??[ 5L        ColumnHeader   ColumnHeaderStyle# [ 5M       	 Row	   RowStyle#	 [	 5N       
 Cell
   	CellStyle#
 [
 5Q      ??5O      ?? *	Employees+ ?? SelectedItem 5P      ?? *SelectedEmployee+   Columns 5S      0  *System.Windows.Controls.DataGridTextColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Header$ ПІБ??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 5V   $   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5U   %   ?? *
FullName+   ElementStyle 5Y      ?? 5Z      .?5[      ??  ?? Property ? ?? ?? Value$
 Wrap=?6G   ?? 5\       ?@??TextAlignment$ Center=?6H   5]      5_        5`      $# Дата народження??6%   $ 4* 5a   &    5b   %   ??  ?? Path$ DateOfBirth? ?? StringFormat$ 
dd.MM.yyyy??5f        5g      $! Номер телефону??6%   $ 4* 5h   &    5i   %   ?? *PhoneNumber+ 5j      ?? 5k      .?5l      ??  ? ??$
 Wrap=?6G   ?? 5m       ?@??TextAlignment$ Center=?6H   5n      5p        5q      $ Поштомат??5r      $ 3* 5s       5t      ?? *Poshtomat.Number+5u      5x      5?      5?      
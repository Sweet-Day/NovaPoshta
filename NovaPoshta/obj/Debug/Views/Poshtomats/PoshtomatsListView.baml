   M S B A M L   `   `   `  ????E  ANovaPoshta, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:NovaPoshta.Views.PoshtomatsNovaPoshta.Views.Poshtomats  5      =#clr-namespace:NovaPoshta.ViewModelsNovaPoshta.ViewModels  5      4    .NovaPoshta.Views.Poshtomats.PoshtomatsListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:NovaPoshta.Views.Poshtomats     5      2vm#clr-namespace:NovaPoshta.ViewModels     5        ? DataContext  5
      3   -NovaPoshta.ViewModels.PoshtomatsListViewModel  5   
   6'    J? InputBindings 5      ?? 5   
   
 ?? Key$ Return??5       ?? Command 5      ?? *SearchPoshtomatCommand+5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $
??0.5* ?6   6.   ?? 5      $
??0.5* ?6   6.   ?? 5      $
??0.5* ?6   6.   ?? 5      $
??0.5* ?6   6.    ? RowDefinitions 5   
   ?? 5      $	??120 ?6   6+   ?? 5      $??50 ?6   6*   ?? 5      $??60 ?6   6*   ?? 5      6   .+?5!   
   ??    WhiteBorder#??[  6   $??5??66   $??4??6J   ._?5"      ??  ?? Orientation$ Vertical=?6   .+?5#      ]? .+?5$      ?? $??Center=?6     
 Header#??[ 6;   $??32(?6[   Поштомати5&      ?? 5(      $??Right=?6!   $ 
Horizontal=?6=   .+?5)      ?? $??/Resources/icons/man.png??6    $??Right=?6B   $??50??6^   6k   ?? 5*        	Paragraph#??[ 6$   $??5q?6G   ??6R   ?? *
LoggedUser+6p   5+      5,      5.      51      ?? 53        TextBoxDefaultStyle#??[ 6   $??4??54      $??1??55      $??30??56      $	??Top=?57      $??
30,0,125,0q?6.   ??58      ?? *SearchString+66   ?? 5:   
     LightRedButton#??[ 6   $	??Top=?5;      $??50??5<      $??1??5=      $??3??5>      $??Center=?5?      ??5@      ?? *SearchPoshtomatCommand+.??5B      ?? $!??/Resources/icons/search.png??6   $??30??69   6F   5C      ?? 5D   
   $??0??6   $??2??6#   $	??140??60   $??30??6<    ?? Text$ Сортування??6H    ?? 
IsEditable . 	 ?? 
IsReadOnly	 .   LightComboBox#??[ 5E      
 ?? SelectedIndex
 6:   ?? *
SortType+.@?5F      ?? -   5        $??Item1??5F   F     LightComboBoxItem#??[ 6   .??6S   За номером6_   ?? 5G      -   5        $??Item2??5G   F   #??[ 6   .??6S   За адресою6_   ?? 5H      -   5        $??Item3??5H   F   #??[ 6   .??6S   За заповненням6c   5J      ?? 5P   
   #??[ 6   $??1??6a   $??2??6q   $	??140??6~   $??30??6?   ??69   ?? *AddPoshtomatCommand+.??6?   Додати6?   ?? 5Q   
   #??[ 6   $??2??6d   $??2??6t   $	??140??6?   $??30??6?   ??69   ?? *UpdatePoshtomatCommand+.??6?   Редагувати6?   ?? 5R   
   #??[ 6   $	??140??6d   $??3??6p   $??2??6?   $??30??6?   ??69   ?? *RemovePoshtomatCommand+.??6?   Видалити6?   &   System.Windows.Controls.DataGrid  5S   
   -   5        $??0??5T         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5U      $??3??5V      $??4??5W        Grid#??[ 5X        ColumnHeader   ColumnHeaderStyle# [ 5Y       	 Row   RowStyle# [	 5Z       
 Cell   	CellStyle# [
 5]      ??5[      ?? *
Poshtomats+ ?? SelectedItem 5\      ?? *SelectedPoshtomat+   Columns 5d      0  *System.Windows.Controls.DataGridTextColumn  5g      ,  &System.Windows.Controls.DataGridColumn   Header$ Поштомат??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5h   %   ?? *Number+  5k      $ Адреса??6%    5l   %   ?? *	Address+5o        5p      $ Заповнений на??6%    5q   %   ?? *QuantityToString+5r      5t      5u      5v      
   M S B A M L   `   `   `  ????E  ANovaPoshta, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NovaPoshta.ViewModelsNovaPoshta.ViewModels  5      E'clr-namespace:NovaPoshta.Views.HomeViewNovaPoshta.Views.HomeView  5      (    "NovaPoshta.Views.HomeView.HomeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2vm#clr-namespace:NovaPoshta.ViewModels     5      9local'clr-namespace:NovaPoshta.Views.HomeView     5        ? DataContext  5
      )  #NovaPoshta.ViewModels.HomeViewModel  5   
   6   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $
??0.4* ?6   6.   ?? 5      6!   .+?5   
   ??  ?? Orientation$ Vertical=?6   .+?5      ?? $??0??6   $	??170??6$   $"??/Resources/icons/image 1.png??60   $
??Left=?6V   $??15q?6q   6   ?? 5      $??0,60,0,0q?6      MenuItem#??[  6'   ??6I   ?? *EmployeesListCommand+.??5      ]? ??6   ??  ?? Path$ 
Background? ?? RelativeSource ?? *FindAncestor+ ?? AncestorType" ?? ?? Mode$ TwoWay=?.+?5      ?? $&?? /Resources/icons/courier (1).png??6   $??60??6F   $
??Left=?6Q   $??10q?6l   6z   ?? 5        ButtonLabel#??[ 6    $??19(?6E    ?? Padding$ 20q?6S   Робітники5      5      5      ?? 5      $??0,20,0,0q?6   #??[  6'   ??6I   ?? *PoshtomatsListCommand+.??5      ]? ??6   ?? $ 
Background? ?? *FindAncestor+" ??$ TwoWay=?.+?5      ?? $'??!/Resources/icons/location-pin.png??6   $??60??6G   $
??Left=?6R   $??10q?6m   6{   ?? 5       #??[ 6    $??19(?6E   $ 20q?6S   Поштомати5"      5#      5$      ?? 5%      $??0,20,0,0q?6   #??[  6'   ??6I   ?? *NotificationsListCommand+.??5&      ]? ??6   ?? $ 
Background? ?? *FindAncestor+" ??$ TwoWay=?.+?5'      ?? $'??!/Resources/icons/notification.png??6   $??60??6G   $
??Left=?6R   $??10q?6m   6{   ?? 5(      #??[ 6    $??19(?6E   $ 20q?6S   Сповіщення5*      5+      5,      5-      ?? 5.   
   #??[  6   $??Bottom=?63    ? Cursor$
 Hand??6n   ??6N   ?? *ExitCommand+.??5/      ]? ??6   ?? $ 
Background? ?? *FindAncestor+" ??$ TwoWay=?.+?50      ?? $ ??/Resources/icons/exit1.png??6   $??50??6<   $
??Left=?6G   $??10q?6b   6p   ?? 51      #??[ 6   $ 20q?6A   
Вихід53      54      55      ?? 56   
   $??
0,15,15,15q?6   $??1??6-   ??6=   ?? *CurrentHomePage+6c   57      59      
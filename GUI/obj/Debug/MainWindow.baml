   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	   /clr-namespace:GUI.ViewModelsGUI.ViewModels  5   	   %clr-namespace:GUI.Views	GUI.Views  5   	       GUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:GUI     5   	   /vmodelclr-namespace:GUI.ViewModels     5   	   (viewclr-namespace:GUI.Views     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)    � 	Resources 5       �� DataType#   GUI.ViewModels.LoginViewModel   GUI.Views.LoginView"   GUI.ViewModels.MainViewModel   GUI.Views.MainView%  GUI.ViewModels.NewUserViewModel   GUI.Views.NewUserView%   GUI.ViewModels.AccountViewModel   GUI.Views.AccountView%	   GUI.ViewModels.CarListViewModel
   GUI.Views.CarListView%  GUI.ViewModels.RentCarViewModel   GUI.Views.RentCarView'   !GUI.ViewModels.ReturnCarViewModel   GUI.Views.ReturnCarView��%  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,	 +)(�� �     5      *, +)(�� ,    5       *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " 	 6   .R�5      
  5      �� 5   
   "  6   .R�5        5      �� 5    
   "  6   .R�5!        5"      5#       � DataContext 5%      $   GUI.ViewModels.WindowViewModel  5&   
   .��5)      � .+�5*   
   �� ��6   �� *CurrentView+5+      5,      
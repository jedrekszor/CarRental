   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Views	GUI.Views  5      /clr-namespace:GUI.ViewModelsGUI.ViewModels  5      /clr-namespace:GUI.ControllerGUI.Controller  5          GUI.Views.MainView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GUI.Views     5      /vmodelclr-namespace:GUI.ViewModels     5      /configclr-namespace:GUI.Controller     5      $	��550��5
      $	��790��6     � 	Resources  5         	BoolToVis��%   &	        �� 5   
   6'   5       � DataContext 5      "   GUI.ViewModels.MainViewModel  5   
   .��5      � 
�������.+�5   
   �� $
��Left=�6*   $��	10,10,0,0q�6E   $	��Top=�6X   ��6   �� *Title+6X   �� 5   
   
�������$
��Left=�6!   $	��100��6<   $��430,133,0,0q�6I   
���   �$	��Top=�6m   $	��216��6�   �� 5   
   $��Logout��6   $
��Left=�6"   $��
10,520,0,0q�6=   $	��Top=�6Q   $��75��6i   ��6t   �� *GoToLoginCommand+ �� Mode$ OneWay=��� 5   
   $��name:��6   $
��Left=�6    $��446,164,0,0q�6;   $	��Top=�6P   �� 5   
   $��surname:��6   $
��Left=�6#   $��446,180,0,0q�6>   $	��Top=�6S   �� 5    
   $
��Left=�6I   $��518,164,0,0q�6d   $	��Top=�6y   ��6   ��  �� Path$% (config:CurrentUserConfig.Name)�6y   �� 5!   
   $
��Left=�6L   $��518,180,0,0q�6g   $	��Top=�6|   ��6   �� $( "(config:CurrentUserConfig.Surname)�6|   �� 5"   
   $��
logged as:��6   $
��Left=�6%   $��446,138,0,0q�6@   $	��Top=�6U   �� 5#   
   $��Account��6   $
��Left=�6#   $��566,208,0,0q�6>   $	��Top=�6S   $��74��6k   ��6v   �� *GoToAccountCommand+$ OneWay=��� 5&   
   $��Rent car��6   $
��Left=�6$   $��460,310,0,0q�6?   $	��Top=�6T   $	��160��6l   $��48��6x   $��16(�6�   
���   �
���������6�   �� *GoToRentCommand+$ OneWay=��� 5'   
   $��
Return car��6   $
��Left=�6&   $��461,379,0,0q�6A   $	��Top=�6V   $	��160��6n   $��46��6z   $��16(�6�   
���   ����	#FFDEDEDE��6�   �� *GoToReturnCommand+$ OneWay=��� 5*   
   $��List of cars��6   $
��Left=�6(   $��501,487,0,0q�6C   $	��Top=�6X   $��75��6p   ��6{   �� *GoToCarListCommand+$ OneWay=��� 5+   
   $��Serch for your best car:��6   $
��Left=�63   $��472,457,0,0q�6N   $	��Top=�6c   �� 5.   
   $��
CarRental_��6   $
��Left=�6%   $��
444,32,0,0q�6@   $	��Top=�6T   $��36(�6l   �� 5/   
   $��application��6   $
��Left=�6&   $��
522,76,0,0q�6A   $	��Top=�6U   $��18(�6m   � 51   
   $
��Left=�6P   $	��474��6k   $��	10,41,0,0q�6x   $	��Top=�6�   $	��307��6�   y�6   �� $* $(config:OrderConfig.OrderVisibility)�.+�53      �� ���	#FFF4F4F5$
��Left=�6)   $	��461��6D   $��5,3,0,0q�6Q   
���   �$	��Top=�6q   $	��292��6�   �� 54      $��Your current order:��6   $
��Left=�62   $��	23,10,0,0q�6M   $	��Top=�6`   $��29��6x   �� 55      $
��Left=�6   $��	32,44,0,0q�63   $
��Wrap=�6F   $	��Top=�6�   $	��411��6�   $	��242��6�   ��6Z   �� $$ (config:OrderConfig.OrderInfo)�6�   56      58      59      
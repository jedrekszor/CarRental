   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Views	GUI.Views  5      /clr-namespace:GUI.ViewModelsGUI.ViewModels  5      /clr-namespace:GUI.ControllerGUI.Controller  5          GUI.Views.MainView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GUI.Views     5      /vmodelclr-namespace:GUI.ViewModels     5      /configclr-namespace:GUI.Controller     5      $	��550��5
      $	��790��6     � DataContext  5      "   GUI.ViewModels.MainViewModel  5   
   .��5      � 
�������.+�5   
   �� $
��Left=�6*   $��	10,10,0,0q�6E   $	��Top=�6X   ��6   �� *Title+6X   �� 5   
   
�������$
��Left=�6!   $	��100��6<   $��
556,15,0,0q�6I   
���   �$	��Top=�6l   $	��215��6�   �� 5   
   $��Logout��6   $
��Left=�6"   $��
10,520,0,0q�6=   $	��Top=�6Q   $��75��6i   ��6t   �� *GoToLoginCommand+ �� Mode$ OneWay=��� 5   
   $��name:��6   $
��Left=�6    $��
572,46,0,0q�6;   $	��Top=�6O   �� 5   
   $��surname:��6   $
��Left=�6#   $��
572,62,0,0q�6>   $	��Top=�6R   �� 5   
   $
��Left=�6I   $��
644,46,0,0q�6d   $	��Top=�6x   ��6   ��  �� Path$% (config:CurrentUserConfig.Name)�6x   �� 5   
   $
��Left=�6L   $��
644,62,0,0q�6g   $	��Top=�6{   ��6   �� $( "(config:CurrentUserConfig.Surname)�6{   �� 5   
   $��
logged as:��6   $
��Left=�6%   $��
572,20,0,0q�6@   $	��Top=�6T   �� 5   
   $��Account��6   $
��Left=�6#   $��
692,90,0,0q�6>   $	��Top=�6R   $��74��6j   ��6u   �� *GoToAccountCommand+$ OneWay=��� 5"   
   $��Rent car��6   $
��Left=�6$   $��147,225,0,0q�6?   $	��Top=�6T   $	��160��6l   $��47��6x   $��16(�6�   
���   �
���������6�   �� *GoToRentCommand+$ OneWay=��� 5#   
   $��
Return car��6   $
��Left=�6&   $��327,225,0,0q�6A   $	��Top=�6V   $	��160��6n   $��47��6z   $��16(�6�   
���   ����	#FFDEDEDE��6�   �� *GoToReturnCommand+$ OneWay=��� 5&   
   ���	#FFF4F4F5$
��Left=�6%   $	��214��6@   $��147,288,0,0q�6M   
���   �$	��Top=�6q   $	��507��6�   �� 5'   
   $��Your current order��6   $
��Left=�6-   $��157,298,0,0q�6H   $	��Top=�6]   �� 5*   
   $��List of cars��6   $
��Left=�6(   $��	10,84,0,0q�6C   $	��Top=�6V   $��75��6n   ��6y   �� *GoToCarListCommand+$ OneWay=��� 5+   
   $��Serch for your best car:��6   $
��Left=�63   $��	10,54,0,0q�6N   $	��Top=�6a   �� 5,   
   $��Admin panel��6   $
��Left=�6'   $��692,120,0,0q�6B   $	��Top=�6W   $��75��6o   �� 5/   
   $��
CarRetnal_��6   $
��Left=�6%   $��
310,62,0,0q�6@   $	��Top=�6T   $��36(�6l   �� 50   
   $��application��6   $
��Left=�6&   $��389,106,0,0q�6A   $	��Top=�6V   $��18(�6n   51      52      
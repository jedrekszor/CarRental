   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Views	GUI.Views  5      /clr-namespace:GUI.ViewModelsGUI.ViewModels  5      /clr-namespace:GUI.ControllerGUI.Controller  5      'clr-namespace:GUI.Helper
GUI.Helper  5	          GUI.Views.RentCarView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GUI.Views     5      /vmodelclr-namespace:GUI.ViewModels     5      /configclr-namespace:GUI.Controller     5      )helpclr-namespace:GUI.Helper     5	      $	��550��5      $	��790��6     � 	Resources  5        GUI.Helper.ParamConverter   ParamConverter��%   &	          5   
   6   5       � DataContext 5      %  GUI.ViewModels.RentCarViewModel  5   
   .��5      � 
�������.+�5   
   �� $
��Left=�6*   $��	10,10,0,0q�6E   $	��Top=�6X   ��6   �� *Title+6X   �� 5   
   $��Go back��6   $
��Left=�6#   $��
10,520,0,0q�6>   $	��Top=�6R   $��75��6j   ��6u   �� *GoBackCommand+ �� Mode$ OneWay=��� 5   
   ���	#FFF4F4F5$
��Left=�6%   $	��405��6@   $��
580,94,0,0q�6M   
���   �$	��Top=�6p   $	��174��6�   �� 5   
   $��4. Confirm order:��6   $
��Left=�6,   $��
580,63,0,0q�6G   $	��Top=�6[   �� 5   
   $��Pickup date:��6   $
��Left=�6'   $��590,115,0,0q�6B   $	��Top=�6W   �� 5   
   $��Price:��6   $
��Left=�6!   $��593,184,0,0q�6<   $	��Top=�6Q   �� 5   
   $��Brand:��6   $
��Left=�6!   $��592,212,0,0q�6<   $	��Top=�6Q   �� 5    
   $��Model:��6   $
��Left=�6!   $��592,241,0,0q�6<   $	��Top=�6Q   �� 5!   
   $��Passengers:��6   $
��Left=�6&   $��590,270,0,0q�6A   $	��Top=�6V   �� 5"   
   $
��Left=�6K   $��672,115,0,0q�6f   $	��Top=�6{   ��6   �� *
PickupDate+ �� StringFormat$ dd MMM yyyy��6{   �� 5#   
   $
��Left=�66   $��639,184,0,0q�6Q   $	��Top=�6f   ��6   �� *SelectedCar.Price+6f   �� 5$   
   $
��Left=�6C   $��642,212,0,0q�6^   $	��Top=�6s   ��6   �� *SelectedCar.Brand+$ OneWay=�6s   �� 5%   
   $
��Left=�6C   $��642,241,0,0q�6^   $	��Top=�6s   ��6   �� *SelectedCar.Model+$ OneWay=�6s   �� 5&   
   $
��Left=�6H   $��666,270,0,0q�6c   $	��Top=�6x   ��6   �� *SelectedCar.Passengers+$ OneWay=�6x   �� 5)   
   $��1. Check client data:��6   $
��Left=�60   $��	24,66,0,0q�6K   $	��Top=�6^   �� 5*   
   $	��Id:��6   $
��Left=�6   $��	24,97,0,0q�69   $	��Top=�6L   �� 5+   
   $��Name:��6   $
��Left=�6    $��
24,123,0,0q�6;   $	��Top=�6O   �� 5,   
   $��Surname:��6   $
��Left=�6#   $��
24,149,0,0q�6>   $	��Top=�6R   �� 5-   
   $
��Left=�6G   $��	91,97,0,0q�6b   $	��Top=�6u    J� RenderTransformOrigin$ 0.079,0.462&�6�   ��6   ��  �� Path$# (config:CurrentUserConfig.Id)�6�   �� 5.   
   $
��Left=�6I   $��
91,123,0,0q�6d   $	��Top=�6x   ��6   �� $% (config:CurrentUserConfig.Name)�6x   �� 5/   
   $
��Left=�6L   $��
91,149,0,0q�6g   $	��Top=�6{   ��6   �� $( "(config:CurrentUserConfig.Surname)�6{   �� 53   
   -   5         ��Name$ 	selectCar��53      $
��Left=�6%   $	��405��6@   $��
180,97,0,0q�6M   $	��Top=�6a   $	��203��6y   ��6�   �� *
FreeCars+ �� SelectedItem 6�   �� *SelectedCar+�� 54   
   $��2. Choose car:��6   $
��Left=�6)   $��
180,66,0,0q�6D   $	��Top=�6X   $��99��6p   $ 0.475,0.577&�6{   �� 57   
   $��3. Choose pickup date:��6   $
��Left=�61   $��
403,66,0,0q�6L   $	��Top=�6`   (  "System.Windows.Controls.DatePicker  58   
   -   5          Name$ selectPickupDate��58      $
��Left=�6/   $��
403,97,0,0q�6J   $	��Top=�6^   	   FirstDayOfWeek$	 Monday=�6�   $	��145��6�   
   SelectedDate
 6v   �� *
PickupDate+$ TwoWay=�   DisplayDateStart 6�   �� *Today+$ OneWay=�6�   �� 5:   
   $��4. Choose return date:��6   $
��Left=�61   $��403,144,0,0q�6L   $	��Top=�6a     5;   
   -   5        $ selectReturnDate��5;      $
��Left=�6/   $��403,175,0,0q�6J   $	��Top=�6_   $	 Monday=�6�   $	��145��6�   
 6w   �� *	RetunDate+$ TwoWay=� 6�   �� *Today+$ OneWay=�6�   �� 5=   
   $��Confirm��6   $
��Left=�6#   $��606,340,0,0q�6>   $	��Top=�6S   $	��118��6k   $��51��6w   ��6�   �� *ConfirmCommand+$ OneWay=���5>      `� 5?       `� 	Converter# [  6   .1�5@      ��  �� ElementName$ 	selectCar��6   $ SelectedItem�66   �� 5A      $ selectPickupDate��6   $ SelectedDate�6=   �� 5B      $ selectReturnDate��6   $ SelectedDate�6=   5C      5E      �� 5H   
   $
��Left=�6   $��72��6/   $��590,413,0,0q�6;   $
��Wrap=�6P   $	��Top=�6{   $	��150��6�   ��6d   �� *Alert+6�   �� 5I   
   $��Return date:��6   $
��Left=�6'   $��590,144,0,0q�6B   $	��Top=�6W   �� 5J   
   $
��Left=�6J   $��672,144,0,0q�6e   $	��Top=�6z   ��6   �� *	RetunDate+$ dd MMM yyyy��6z   5L      5M      
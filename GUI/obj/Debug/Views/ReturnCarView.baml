   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Views	GUI.Views  5      /clr-namespace:GUI.ViewModelsGUI.ViewModels  5      'clr-namespace:GUI.Helper
GUI.Helper  5          GUI.Views.ReturnCarView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GUI.Views     5      /vmodelclr-namespace:GUI.ViewModels     5      )helpclr-namespace:GUI.Helper     5      $	��550��5
      $	��790��6     � 	Resources  5        GUI.Helper.ParamConverter   ParamConverter��%   &	          5   
   6   5       � DataContext 5      '   !GUI.ViewModels.ReturnCarViewModel  5   
   .��5      � 
�������.+�5   
   �� $
��Left=�6*   $��	10,10,0,0q�6E   $	��Top=�6X   ��6   �� *Title+6X   �� 5   
   ���	#FFF4F4F5$
��Left=�6%   $	��255��6@   $��
26,211,0,0q�6M   
���   �$	��Top=�6p   $	��741��6�   �� 5   
   $��Confirm��6   $
��Left=�6#   $��625,394,0,0q�6>   $	��Top=�6S   $	��126��6k   $��53��6w   ��6�   �� *ConfirmCommand+ �� Mode$ OneWay=���5      `� 5       `� 	Converter# [  6   .1�5      ��  �� ElementName$ Distance��6    �� Path$
 Text�65   �� 5      $ 
PickupDate��6   $ SelectedDate�67   �� 5      $ Feedback��6   $ SelectedItem�65   5      5!      �� 5"   
   $��Go back��6   $
��Left=�6#   $��
10,520,0,0q�6>   $	��Top=�6R   $��75��6j   ��6u   �� *GoToHomeCommand+$ OneWay=��� 5%   
   -   5         ��Name$ Distance��5%      $
��Left=�6$   $��23��6?   $��
47,262,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6�   $	��309��6�   ��6s   �� *DistanceDriven+6�   �� 5&   
   $��Distance driven (km):��6   $
��Left=�60   $��
47,231,0,0q�6K   $	��Top=�6_   �� 5)   
   $��Return date:��6   $
��Left=�6'   $��
47,303,0,0q�6B   $	��Top=�6V   (  "System.Windows.Controls.DatePicker  5*   
   -   5          Name$ 
PickupDate��5*      $
��Left=�6)   $��
47,334,0,0q�6h   $	��Top=�6|   $	��309��6�   	   SelectedDate	 6D   �� *
ReturnDate+
   DisplayDateStart
 6�   �� *Today+�� 5-   
   $2��,Give us feedback, measure your satisfaction:��6   $
��Left=�6G   $��
47,376,0,0q�6b   $	��Top=�6v   �� 5.   
   -   5         ��Name$ Feedback��5.      $
��Left=�6%   $��
47,407,0,0q�6@   $	��Top=�6T   $	��309��6l    �� SelectedItem 6x   �� *
Feedback+��6�   �� *FeedbackOpts+�� 51   
   $��Final price (zł):��6   $
��Left=�6,   $��625,312,0,0q�6G   $	��Top=�6\   �� 52   
   $
��Left=�6/   $��625,342,0,0q�6J   $	��Top=�6_   ��6   �� *
FinalPrice+6_   �� 55   
   $
��Left=�6   $��	26,72,0,0q�6/   $
��Wrap=�6B   $����Am congue nunc in sem eleifend tempor. Integer venenatis congue enim, vitae maximus ipsum sagittis ac. Donec ut nulla pellentesque, auctor quam quis, accumsan nunc. Integer pellentesque leo ut odio condimentum, non posuere dui consequat. Nulla facilisi. Duis pharetra luctus nibh sed ultricies. Donec venenatis justo a sem rhoncus ullamcorper. Nam id blandit felis. Aenean vitae commodo felis. Pellentesque sodales ultricies leo, eget rhoncus mi rhoncus a.��6V   $	��Top=�6&  $	��103��6>  $	��461��6K   �� TextAlignment$ Justify=�6W  �� 58   
   $��
CarRental_��6   $
��Left=�6%   $��
575,28,0,0q�6@   $	��Top=�6T   $��36(�6l   �� 59   
   $��application��6   $
��Left=�6&   $��
653,72,0,0q�6A   $	��Top=�6U   $��18(�6m   5;      5<      
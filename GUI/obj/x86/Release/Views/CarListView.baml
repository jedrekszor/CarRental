   M S B A M L   `   `   `  ���� >  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Views	GUI.Views  /clr-namespace:GUI.ViewModelsGUI.ViewModels  /clr-namespace:GUI.ControllerGUI.Controller      GUI.Views.CarListView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:GUI.Views     /vmodelclr-namespace:GUI.ViewModels     /configclr-namespace:GUI.Controller     $	��550��$	��790��  � DataContext  %   GUI.ViewModels.CarListViewModel  .��� 
�������.+��� $��Go back��$
��Left=�$��
10,520,0,0q�$	��Top=�$��76������ *GoToHomeCommand+ �� Mode$ OneWay=��� $
��Left=�$��	10,10,0,0q�$	��Top=����� *Title+�� ���	#FFF4F4F5$
��Left=�
���   �$	��746��$��20,106,0,50q��� $��37,123,45,68q����� *Cars+���� .R���  �� Orientation$ Vertical=�.+��� ���� *Brand+�� ���� *Model+�� ���� *
Passengers+�� ���� *Price+�� $
��Left=�$��	10,10,0,0q�$	��Top=� J� RenderTransformOrigin$ -0.013,0.135&����� *Title+�� $<��6Below are presented all cars available in our company.��$
��Left=�$��	20,62,0,0q�$	��Top=��� $t��nMind that some of them can be occupied now. If you want to see cars ready to be rent, go to 'Rent car' Section��$
��Left=�$��	20,75,0,0q�$	��Top=��� $��Rent Car��$
��Left=�$��
691,78,0,0q�$	��Top=�$��75������ *GoToRentCarCommand+$ OneWay=�
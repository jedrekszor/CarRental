   M S B A M L   `   `   `  ���� >  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Views	GUI.Views  /clr-namespace:GUI.ViewModelsGUI.ViewModels  /clr-namespace:GUI.ControllerGUI.Controller      GUI.Views.MainView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:GUI.Views     /vmodelclr-namespace:GUI.ViewModels     /configclr-namespace:GUI.Controller     $	��550��$	��790��  � DataContext  "   GUI.ViewModels.MainViewModel  .��� 
�������.+��� $
��Left=�$��	10,10,0,0q�$	��Top=����� *Title+�� 
�������$
��Left=�$	��100��$��
556,15,0,0q�
���   �$	��Top=�$	��215���� $��Logout��$
��Left=�$��
10,520,0,0q�$	��Top=�$��75������ *GoToLoginCommand+ �� Mode$ OneWay=��� $��name:��$
��Left=�$��
572,46,0,0q�$	��Top=��� $��surname:��$
��Left=�$��
572,62,0,0q�$	��Top=��� $
��Left=�$��
644,46,0,0q�$	��Top=�����  �� Path$% (config:CurrentUserConfig.Name)��� $
��Left=�$��
644,62,0,0q�$	��Top=����� $( "(config:CurrentUserConfig.Surname)��� $��
logged as:��$
��Left=�$��
572,20,0,0q�$	��Top=��� $��Account��$
��Left=�$��
692,90,0,0q�$	��Top=�$��74������ *GoToAccountCommand+$ OneWay=��� $��Rent car��$
��Left=�$��147,225,0,0q�$	��Top=�$	��160��$��47��$��16(�
���   �
����������� *GoToRentCommand+$ OneWay=��� $��
Return car��$
��Left=�$��327,225,0,0q�$	��Top=�$	��160��$��47��$��16(�
���   ����	#FFDEDEDE���� *GoToReturnCommand+$ OneWay=��� ���	#FFF4F4F5$
��Left=�$	��214��$��147,288,0,0q�
���   �$	��Top=�$	��507���� $��Your current order��$
��Left=�$��157,298,0,0q�$	��Top=��� $��List of cars��$
��Left=�$��	10,84,0,0q�$	��Top=�$��75������ *GoToCarListCommand+$ OneWay=��� $��Serch for your best car:��$
��Left=�$��	10,54,0,0q�$	��Top=��� $��Admin panel��$
��Left=�$��692,120,0,0q�$	��Top=�$��75���� $��
CarRetnal_��$
��Left=�$��
310,62,0,0q�$	��Top=�$��36(��� $��application��$
��Left=�$��389,106,0,0q�$	��Top=�$��18(�
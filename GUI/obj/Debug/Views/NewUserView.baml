   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Views	GUI.Views  5      /clr-namespace:GUI.ViewModelsGUI.ViewModels  5      'clr-namespace:GUI.Helper
GUI.Helper  5          GUI.Views.NewUserView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GUI.Views     5      /vmodelclr-namespace:GUI.ViewModels     5      )helpclr-namespace:GUI.Helper     5      $	��550��5
      $	��790��6     � 	Resources  5        GUI.Helper.ParamConverter   ParamConverter��%   &	          5   
   6   5       � DataContext 5      %  GUI.ViewModels.NewUserViewModel  5   
   .��5      � 
�������.+�5   
   �� $
��Left=�6*   $��	10,10,0,0q�6E   $	��Top=�6X   ��6   �� *Title+6X   �� 5   
   $
��name��6   $
��Left=�6   $��135,213,0,0q�6:   $	��Top=�6O    J� RenderTransformOrigin$ 0.275,0.538&�6g   �� 5   
   -   5         ��Name$ nameTextBox��5      $
��Left=�6'   $��22��6B   $��183,217,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��200��6�   �� 5   
   $��surname��6   $
��Left=�6"   $��121,251,0,0q�6=   $	��Top=�6R   �� 5   
   -   5        $ surnameTextBox��5      $
��Left=�6*   $��22��6E   $��183,255,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��200��6�   �� 5   
   $��
licence no��6   $
��Left=�6%   $��114,287,0,0q�6@   $	��Top=�6U   �� 5   
   -   5        $ licNoTextBox��5      $
��Left=�6(   $��22��6C   $��183,291,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��200��6�   �� 5    
   $	��age��6   $
��Left=�6   $��148,321,0,0q�69   $	��Top=�6N   �� 5!   
   -   5        $ 
ageTextBox��5!      $
��Left=�6&   $��22��6A   $��183,325,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��200��6�   �� 5$   
   $��Submit��6   $
��Left=�6"   $��234,435,0,0q�6=   $	��Top=�6R   $��75��6j   ��6u   �� *SubmitCommand+ �� Mode$ OneWay=���5%      `� 5&       `� 	Converter# [  6   .1�5'      ��  �� ElementName$ nameTextBox��6    �� Path$
 Text�68   �� 5(      $ surnameTextBox��6   $
 Text�6;   �� 5)      $ licNoTextBox��6   $
 Text�69   �� 5*      $ 
ageTextBox��6   $
 Text�67   5+      5-      �� 5.   
   $��Go back��6   $
��Left=�6#   $��
10,520,0,0q�6>   $	��Top=�6R   $��75��6j   ��6u   �� *GoToMainCommand+$ OneWay=��� 51   
   $!��I agree with company policy��6   $
��Left=�69   $��422,420,0,0q�6T   $	��Top=�6i   	 d� 	IsChecked	 6�   �� *	CheckBox1+�� 52   
   $*��$Yes, yes ... I am responsible person��6   $
��Left=�6B   $��422,440,0,0q�6]   $	��Top=�6r   	 6�   �� *	CheckBox2+�� 53   
   $
��Left=�6   $	��257��6/   $��422,165,0,0q�6<   $
��Wrap=�6Q   $����Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent porttitor odio vel ex dictum facilisis. Praesent nisl orci, laoreet in sem ac, iaculis efficitur lacus. Sed vehicula erat vel ipsum lobortis viverra. Nulla id tempus magna. Nullam faucibus augue a augue convallis interdum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Ut tempor scelerisque metus. Quisque ut erat consequat, vulputate metus vitae, facilisis nunc. Donec sit amet porta leo, sed aliquam lectus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Phasellus id mauris purus. Integer commodo dui vitae tellus faucibus interdum quis eget turpis. Fusce quis gravida purus. Aliquam ut massa nec lorem vestibulum scelerisque.��6e   $	��Top=�6c  $	��294��6{  
 �� TextAlignment$
 Justify=�6�  �� 55   
   $
��Left=�6*   $��137,396,0,0q�6E   $	��Top=�6Z   ��6   �� *Alert+6Z   �� 56   
   $��
CarRental_��6   $
��Left=�6%   $��
316,47,0,0q�6@   $	��Top=�6T   $��36(�6l   �� 57   
   $��application��6   $
��Left=�6&   $��
395,91,0,0q�6A   $	��Top=�6U   $��18(�6m   59      5:      
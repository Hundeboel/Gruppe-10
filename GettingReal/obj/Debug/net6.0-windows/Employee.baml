   M S B A M L   `   `   `  ����A  =WPFapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFappWPFapp  5   	       WPFapp.Employee   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFapp     5   	     � Title$  Employee��5   	   $	��640��6   $	��360��6'   
���"�"� � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ CanMinimize=�6.   .��5
      � .+�5   
   �� -   5         ��Name$ Label_Index��5      $��Index��6%   $
��Left=�65   $��
100,50,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ Label_Count��5      $��Count��6%   $
��Left=�65   $��
200,50,0,0q�6P   $	��Top=�6d   �� 5   
   -   5         ��Name$ CheckBox_IsInvis��5      $
��Left=�6-   $��
300,55,0,0q�6H   $	��Top=�6\   6�   �� 5   
   -   5        $ Label_FirstName��5      $��Fornavn��6)   $
��Left=�6;   $��100,100,0,0q�6V   $	��Top=�6k   �� 5   
   -   5        $ Label_LastName��5      $��	Efternavn��6(   $
��Left=�6<   $��100,150,0,0q�6W   $	��Top=�6l   �� 5   
   -   5        $ 
Label_Role��5      $��Rolle��6$   $
��Left=�64   $��100,200,0,0q�6O   $	��Top=�6d   �� 5   
   -   5        $ Label_UNKNOWN��5      $��??? Tal��6'   $
��Left=�69   $��100,250,0,0q�6T   $	��Top=�6i   �� 5   
   -   5        $ Label_Checkbox��5      $��Checkbox��6(   $
��Left=�6;   $��100,300,0,0q�6V   $	��Top=�6k   �� 5   
   -	   5        $ Label_DatePicker��5      $��Checkbox��6*   $
��Left=�6=   $��100,350,0,0q�6X   $	��Top=�6m   �� 5   
   -
   5         ��Name$ TextBox_FirstName��5      $
��Left=�6-   $��200,100,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��120��6�   ${�False��6�   6�   �� 5   
   -   5        $ TextBox_LastName��5      $
��Left=�6,   $��200,150,0,0q�6G   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��120��6�   ${�False��6�   6�   �� 5   
   -   5         ��Name$ ComboBox_Role��5      $
��Left=�6*   $��200,200,0,0q�6E   $	��Top=�6Z   $	��120��6r   ${�False��6�   .@�5      �� .��6   Svend6"   �� 5      .��6   Mester6#   5      �� 5   
   -   5        $ TextBox_UNKNOWN��5      $
��Left=�6+   $��200,250,0,0q�6F   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��120��6�   ${�False��6�   6�   �� 5   
   -   5        $ CheckBox_Status��5      $
��Left=�6,   $��200,305,0,0q�6G   $	��Top=�6\   ${�False��6t   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatePicker_Date��5      $
��Left=�6.   $��200,350,0,0q�6I   $	��Top=�6^   $	��120��6v   ${�False��6�   	   FirstDayOfWeek$	 Monday=�6�   �� 5    
   -   5        
 ��Name$
 Button_NewEmployee��5       $��Ny ansat��6-   $
��Left=�6@   $��	0,100,0,0q�6[   $	��Top=�6n   $��80��6�   6�   �� 5!   
   -   5        $
 Button_Edit��5!      $��Redigér��6&   $
��Left=�68   $��	0,150,0,0q�6S   $	��Top=�6f   $��80��6~   ${�False��6�   �� 5"   
   -   5        $
 Button_Prev��5"      $��Tidligere profil��6&   $
��Left=�6A   $��	0,200,0,0q�6\   $	��Top=�6o   $��80��6�   ${�False��6�   �� 5#   
   -   5        $
 Button_Next��5#      $��Næste profil��6&   $
��Left=�6=   $��	0,250,0,0q�6X   $	��Top=�6k   $��80��6�   ${�False��6�   �� 5$   
   -   5        $
 
Button_Del��5$      $��Slet profil��6%   $
��Left=�6;   $��	0,300,0,0q�6V   $	��Top=�6i   $��80��6�   ${�False��6�   �� 5%   
   -   5        $
 Button_Save��5%      $��
Gem profil��6&   $
��Left=�6;   $��	0,350,0,0q�6V   $	��Top=�6i   $��80��6�   $
{�True��6�   �� 5'   
   -   5        $
 Button_MainPage��5'      $��	Main Page��6*   $
��Left=�6>   $��	10,10,0,0q�6Y   $	��Top=�6l   $	��100��6�   6�   5)      5*      
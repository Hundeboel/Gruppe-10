   M S B A M L   `   `   `  ����A  =WPFapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFappWPFapp  5   	       WPFapp.Project   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFapp     5   	     � Title$  Project��5   	   $	��640��6   $	��360��6&   
���\\�� � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ CanMinimize=�6.   .��5
      � .+�5   
   �� -   5         ��Name$ Label_Index��5      $��Index��6%   $
��Left=�65   $��
100,50,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ Label_Count��5      $��Count��6%   $
��Left=�65   $��
200,50,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ 
Label_Name��5      $
��Navn��6$   $
��Left=�63   $��100,100,0,0q�6N   $	��Top=�6c   �� 5   
   -   5        $ Label_Finished��5      $��Finished��6(   $
��Left=�6;   $��100,150,0,0q�6V   $	��Top=�6k   �� 5   
   -   5        $ Label_StartDate��5      $��	Startdato��6)   $
��Left=�6=   $��100,200,0,0q�6X   $	��Top=�6m   �� 5   
   -   5        $ Label_EndDate��5      $��Slutdato��6'   $
��Left=�6:   $��100,250,0,0q�6U   $	��Top=�6j   �� 5   
   -   5         ��Name$ TextBox_Name��5      $
��Left=�6(   $��200,100,0,0q�6C    �� TextWrapping$
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $	��120��6�   ${�False��6�   �� 5   
   -   5        $ TextBox_Finished��5      $
��Left=�6,   $��200,150,0,0q�6G   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��120��6�   ${�False��6�   (  "System.Windows.Controls.DatePicker  5   
   -	   5          Name$ DatePicker_StartDate��5      $
��Left=�63   $��200,200,0,0q�6N   $	��Top=�6c   $	��120��6{   ${�False��6�      FirstDayOfWeek$ Monday=�6�     5   
   -
   5        $ DatePicker_EndDate��5      $
��Left=�61   $��200,250,0,0q�6L   $	��Top=�6a   $	��120��6y   ${�False��6�   $ Monday=�6�   �� 5   
   -   5         ��Name$ Button_NewProject��5      $��Nyt projekt��6,   $
��Left=�6B   $��100,300,0,0q�6]   $	��Top=�6r   $	��100��6�   6�   �� 5   
   -   5        $ Button_Edit��5      $��Redigér��6&   $
��Left=�68   $��100,350,0,0q�6S   $	��Top=�6h   $	��100��6�   ${�False��6�   �� 5   
   -   5        $ Button_Prev��5      $��Tidligere projekt��6&   $
��Left=�6B   $��100,400,0,0q�6]   $	��Top=�6r   $	��100��6�   ${�False��6�   �� 5   
   -   5        $ Button_Next��5      $��Næste projekt��6&   $
��Left=�6>   $��100,450,0,0q�6Y   $	��Top=�6n   $	��100��6�   ${�False��6�   �� 5   
   -   5        $ 
Button_Del��5      $��Slet Projekt��6%   $
��Left=�6<   $��100,500,0,0q�6W   $	��Top=�6l   $	��100��6�   ${�False��6�   �� 5   
   -   5        $ Button_Show��5      $��Vis Projekter��6&   $
��Left=�6>   $��100,550,0,0q�6Y   $	��Top=�6n   $	��100��6�   6�   �� 5   
   -   5        	 ��Name$	 CheckBox_Finished��5      $
��Left=�6.   $��325,150,0,0q�6I   $	��Top=�6^   ${�False��6v   6�   �� 5!   
   -   5        $ Button_MainPage��5!      $��	Main Page��6*   $
��Left=�6>   $��	10,10,0,0q�6Y   $	��Top=�6l   $	��100��6�   6�   5"      5#      
   M S B A M L   `   `   `  ����E  ASQLiteDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SQLiteDemo
SQLiteDemo  5   	       SQLiteDemo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SQLiteDemo     5   	     � Title$&   SQLite Database Test Application��5   	   $	��450��62   $	��800��6?   
�������.��5
      � $��5q�6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��0��5      $��
Add Person��6"   $	��100��6G   �� 5      -   5        $��txtRandomPeople��5      $��1��6-   $��30��66    �� TextAlignment$ Center=�6A   $��5q�6X   �� 5      -   5        $��0��5      $��
Add Random��6"   $	��100��6M   �� 5      -   5        $��0��5      $��Remove Person��6"   $	��100��6M   �� 5      $��First Name:��6   �� 5      -   5        $��txtFirstName��5      $	��150��6*   �� 5      $��
Last Name:��6   �� 5      -   5        $��txtLastName��5      $	��150��6*   5      �� 5   
   -   5        $��	listView1��5      $��Disabled=�6$   $��1��6Z    �� AlternationCount$ 2��6g   $��1q�5      $��	0,5,0,4.5q�6'    �� SelectionMode$ Multiple=�6:   ��5      ��  �� View 5      �� 5       .P�5!      �� $��PersonID��6%    �� Width$	 100��67    �� DisplayMemberBinding 6C   �� *
PersonID+�� 5"      $��
First Name��6%   $	 100��69    6E   �� *	FirstName+�� 5#      $��	Last Name��6%   $	 100��68    6D   �� *
LastName+�� 5$      $��Phone��6%   $	 100��64    6@   �� *Phone+5%      5'      �� 5(   
   $��2��6   $ 
Horizontal=�6"   
�������.+�5)      �� $��Number of people: ��6   �� 5*      -   5        $��txtNumberofPeople��5*      $��0��61   $��Center=�6:   $
��Left=�6U   $��40��6p   �� 5+      $��18��6   $��1q�6!   
���   �$��4q�6I   �� 5,      $!��Number of people selected: ��6   �� 5-      -	   5        $��txtNumberSelected��5-      $��0��61   $��Center=�6:   $
��Left=�6U   5/      50      52      
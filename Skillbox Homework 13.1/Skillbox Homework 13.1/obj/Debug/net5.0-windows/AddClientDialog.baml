   M S B A M L   `   `   `  ����Q  MSkillbox Homework 13.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Skillbox_Homework_13._1Skillbox_Homework_13._1  5   	   -    'Skillbox_Homework_13._1.AddClientDialog   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Skillbox_Homework_13._1     5   	     � Title$)  #Добавление клиента��5   	   $	��450��6$   $	��600��61   $	��450��6=   $	��600��6M   $	��450��6\   $	��600��6l   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��400* �6   �� 5      $	��80* �6   �� 5      $
��400* �6    � RowDefinitions 5   
   �� 5      $	��70* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $
��159* �6   .+�5   
   ]� $
��true��6   $��1��6)   .+�5      �� $��Фамилия:��6   $��NoWrap=�6(   $	��271��6>    �� TextAlignment$ Center=�6J   5      ]� 5   
   $
��true��6   $��3��6)   .+�5      �� $��Имя:��6   $
��Wrap=�6$   $	��271��68   $ Center=�6D   5       ]� 5!   
   $
��true��6   $��5��6)   .+�5"      �� $��Отчество:��6   $
��Wrap=�6)   $	��271��6=   $ Center=�6I   5#      ]� 5$   
   $��2��6   $
��true��6$   $��1��69   .+�5%      �� -   5        $��textboxSecondName��5%      $�� ��60    �� TextWrapping$
 Wrap=�68   $	��250��6L    �� TextAlignment$ Center=�6X   5&      ]� 5'   
   $��2��6   $
��true��6$   $��3��69   .+�5(      �� -   5        $��textboxFirstName��5(      $�� ��6/   $
 Wrap=�67   $	��250��6K   $ Center=�6W   5)      ]� 5*   
   $��2��6   $
��true��6$   $��5��69   .+�5+      �� -   5        $��textboxPatronymic��5+      $�� ��6/   $
 Wrap=�67   $	��250��6K   $ Center=�6W   5,      �� 5-   
   -   5        $��Добавить��5-      $��2��6$   $��Center=�64   $��8��6Q   $��Center=�6^   $��31��6y   $	��150��6�   6�   5.      5/      
   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  
MainWindow��5   	   $	��700��6   $
��1040��6)   $	��600��66   $	��700��6E   .��5	      �� .@�5
   
   �� $��
Заказ��6   $��16(�6!   .��5      � .+�5      �� $
��Auto=�6   $��10,348,10,10q�6B   .��5      � -   5        $��ProductsWrap��5       $��Stretch=�65   $��Stretch=�6Q   5      �� 5      $
��Auto=�6   $��10,10,10,348q�6B   .��5      � -   5        $��CartWrap��5       $��Stretch=�60   $��Stretch=�6N   5      �� 5      $��Оплата��6   $��Stretch=�6+   $��76��6I   $	��Top=�6U   $��10,270,10,0q�6m   .��5      � .+�5      �� $��201,19,312,2q�6u   ��6"   ��  �� Path$ 
SearchText� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6u   �� 5      $��
Поиск��6    $��201,-4,312,25q�60   �� 5      $��К оплате:��6    $	��164��64   $
��Left=�6@   $��20(�6[   $��10,6,0,6q�6i   �� 5      $��98��6?   $
��Left=�6J   $
��Bold"�6e   
��� � �$��30(�6�   $��	103,0,0,0q�6�   ��6    �� $ ToPay�6�   �� 5      $	��146��6H   $��Right=�6T   $��Отмена��6p   $��Medium"�6�   ���	#FFFFBABA$��25(�6�   $��0,6,10,2q�6�   ��6!   �� $ CancelCommand���5      �� 5   "    �� EndPoint$	 1,1&�66    � MappingMode$ RelativeToBoundingBox=�6E    �� 
StartPoint$	 0,0&�6i   .��5   &   �  � Color$ 	#FF9E0000��63    � Offset$ 0.992Q�6E   � 5   &   $	 Red��63   5   #   5      �� 5       $	��146��6E   $��Right=�6Q   $��Оплатить��6m   $��Medium"�6�   
��� � �$��25(�6�   $��	0,6,161,2q�6�   ��6!   �� $ 
PayCommand���5!      �� 5"   "   $	 1,1&�66   $ RelativeToBoundingBox=�6E   $	 0,0&�6i   .��5#   &   � $ 	#FFDCFFB8��63   $ 0.992Q�6E   � 5$   &   $ 	#FF75EA00��63   5%   #   5'      5(      5)      5*      5+      �� 5,   
   $��История��6   $��16(�6#   .��5-      � .+�5.      &   System.Windows.Controls.DataGrid  	   
IsReadOnly	 . 
   AutoGenerateColumns
 .  $��Stretch=�6�   $
��Left=�6�   $��
10,10,0,10q�6�   $	��230��6�   ��6-   �� $ History� �� SelectedItem 6R   �� $ HistoryItem�   Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *Date+  51      $ Цена��6-   $ 70 6;    6F   �� *Price+53      �� 54      $��Stretch=�6   $��264,10,10,200q�68    �� 
IsReadOnly .  �� TextWrapping$
 Wrap=�6a   $��20(�6�   $��Stretch=�6�   ��6u   �� $ RecieptText�$ OneWay=�6�   55      56      �� 57   
   $��Все товары��6   $��16(�6&   .��58      � .+�59      �� $��
Поиск��6   $
��Left=�6(   $	��Top=�6C   $��10,4,0,0q�6[   �� 5:      $��Stretch=�6`   $	��Top=�6~   $��28��6�   $��
70,10,10,0q�6�   ��6   �� $ 
SearchText�$ PropertyChanged=�6�   �� 5;      $
��Auto=�6   $��10,43,10,10q�6B   .��5<      � -   5        $��AllProductsWrap��5<       $��Stretch=�68   $��Stretch=�6T   5=      5>      5?      5@      5A      
   M S B A M L   `   `   `  ���� B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2      WpfApp2.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp2       � Title$  
MainWindow��$	��700��$
��1040��$	��600��$	��700��.���� .@��� $��
Заказ��$��16(�.��� .+��� $
��Auto=�$��10,348,10,10q�.��� -   $��ProductsWrap��$��Stretch=�$��Stretch=��� $
��Auto=�$��10,10,10,348q�.��� -   $��
BasketWrap��$��Stretch=�$��Stretch=��� $��Оплата��$��Stretch=�$��76��$	��Top=�$��10,270,10,0q�.��� .+��� $��К оплате:��$	��164��$
��Left=�$��20(�$��10,6,0,6q��� $	��144��$
��Left=�$
��Bold"�
��� � �$��30(�$��	103,0,0,0q�����  �� Path$ ToPay��� $	��146��$��Right=�$��Отмена��$��Medium"����	#FFFFBABA$��25(�$��0,2,10,6q����� $ CancelCommand�����  �� EndPoint$	 1,1&� � MappingMode$ RelativeToBoundingBox=� �� 
StartPoint$	 0,0&�.���  � Color$ 	#FF9E0000�� � Offset$ 0.992Q�� $	 Red���� $	��146��$��Right=�$��Оплатить��$��Medium"�
��� � �$��25(�$��	0,0,161,8q����� $ 
PayCommand����� $	 1,1&�$ RelativeToBoundingBox=�$	 0,0&�.��� $ 	#FFDCFFB8��$ 0.992Q�� $ 	#FF75EA00���� $��История��$��16(�.��� .+�&   System.Windows.Controls.DataGrid     AutoGenerateColumns .  $��Stretch=�$
��Left=�$��
10,10,0,10q�$	��230������ $ History� �� SelectedItem �� $ HistoryItem�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Дата��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Date+  $
 Цена��$ 70  �� *Price+�� $��Stretch=�$��264,10,10,200q� �� 
IsReadOnly .  �� TextWrapping$
 Wrap=�$��20(�$��Stretch=����� $ RecieptText� �� Mode$ OneWay=�
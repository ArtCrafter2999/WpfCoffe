   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.ProductModifier   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  ProductModifier��5   	    � 
ResizeMode$ NoResize=�6!   $	��457��67   $	��273��6D   .��5	      � .+�5
   
   �� $��
10,10,10,0q�66   $��Stretch=�6J   $	��Top=�6h   $	��167��6�   ��6   ��  �� Path$ ImageButton�.��5      �� $��5q�62   ��6   �� $ Image�62   5      �� 5   
   $��Название��6   $	��Top=�6#   $��16(�6<   $��10,177,10,0q�6J   �� 5   
   $��16(�6T   $	��Top=�6b   $��33��6z   $��10,206,10,0q�6�   ��6   �� $ PTitle� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Цена��6   $	��Top=�6   $��16(�67   $��10,239,10,0q�6E   �� 5   
   $��16(�6S   $	��Top=�6a   $��33��6y   $��10,270,10,0q�6�   ��6   �� $ Price�$ PropertyChanged=�6�   �� 5   
   $��Категория��6   $	��Top=�6$   $��16(�6<   $��10,303,10,0q�6J   �� 5   
   $	��Top=�6�   $��Stretch=�6�   $��33��6�   $��10,334,10,0q�6�   ��6   �� $ 
Categories� �� SelectedItem 6;   �� $ Category�$ PropertyChanged=�6�   �� 5   
   $��16(�6V   $	��Top=�6d   $��33��6|   $��10,334,30,0q�6�   ��6   �� $ Category�$ PropertyChanged=�6�   �� 5   
   $
��Ок��63   $
��Bold"�6@   $��16(�6R   
��� � �
�������$��199,381,10,10q�6�   ��6   �� $ OkButton�6�   �� 5   
   $��Удалить��67   $
��Bold"�6I   $��16(�6[   
���  ��
�������$��10,381,171,10q�6�   ��6   �� $ DeleteButton�6�   5      5      
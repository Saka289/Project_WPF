   M S B A M L   `   `   `  ����?  ;Lab2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab2Lab2  5   	       Lab2.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      $��2* �6   6,   .+�5   
   �� .+�5      �� $��	ProductId��6   6*   �� 5      -   5         ��Name$ Id��5       �� 
IsReadOnly$
 True��6"   $��29��64   6B   �� 5      $��ProductName��6   6,   �� 5      -   5        $
 Name��5      $��27��6$   �� 5      $��Category Name��6   6.   �� 5      -   5         ��Name$ Category��5      6+   �� 5      $��QuantityPerUnit��6   60   �� 5      -   5        $ Quantity��5      $��29��6(   66   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $��Discontinued��6   61   	� 5      -   5         	�Name$ Discontinued��5      $��Bottom=�64   $��24px 0px 0px 0pxq�6P   $��Enable��6j   $��20��6{   $��74��6�   6�   	� 5      -   5        $ Discontinued1��5      $��Bottom=�65   $��Disable��6P   $��20��6b   $��99��6n    J� RenderTransformOrigin$ 0.874,0.775&�6y   5      �� 5      $��	UnitPrice��6   6*   �� 5      -   5        $ Price��5      $��29��6%   63   ]� 5      .+�5      �� -   5        $��26��5      $��89��6%   .��6E   Add6J   �� 5       -	   5        $��89��5       $��26��6$   .��6G   Edit6M   �� 5!      -
   5        $��26��5!      $��89��6%   .��6G   Delete6O   5"      �� 5#      -   5        $��32��5#      $��90��6!   .��6C   Save6I   5$      �� 5%   
   -   5         ��Name$ 
LbProducts��5%      $��0��6&   $��1��63   ��5&      �� 5'      .R�5(      �� $ 
Horizontal=�6!   .+�5)      �� ��6    �� 	 �� Path$	 	ProductId�
 �� Mode$
 OneWay=�6R   �� 5*      ��6    �� $	 ProductName�$
 OneWay=�6T   �� 5+      ��6    �� $	 QuantityPerUnit�$
 OneWay=�6X   �� 5,      ��6    �� $	 Discontinued�$
 OneWay=�6U   �� 5-      ��6    �� $	 	UnitPrice�$
 OneWay=�6R   �� 5.      ��6    �� $	 Category.CategoryName�$
 OneWay=�6^   5/      50      52      53      54      
   M S B A M L   `   `   `  ����J  FProyecto_Progra, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Proyecto_PrograProyecto_Progra  5   	   "    Proyecto_Progra.VentanaVenta   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Proyecto_Progra     5   	     � Title$  VentanaVenta��5   	   $	��432��6   $	��493��6+   .��5	      � $��Center=�6   $��Center=�6&   $	��493��6C   $	��421��6O   .+�5
   
   ��  �� TextAlignment$ Center=�6   $
��Left=�6+   $��	34,91,0,0q�6F   $
��Wrap=�6Y   $��JUEGO��6m   $	��Top=�6z   $��22��6�   $��45��6�   �� 5   
   $ Center=�6   $
��Left=�6+   $��
34,124,0,0q�6F   $
��Wrap=�6Z   $��PRECIO��6n   $	��Top=�6|   $��22��6�   $��45��6�   �� 5   
   $ Center=�6   $
��Left=�6+   $��
34,158,0,0q�6F   $
��Wrap=�6Z   $��CANTIDAD��6n   $	��Top=�6~   $��22��6�   �� 5   
   $ Center=�6   $
��Left=�6+   $��
34,198,0,0q�6F   $
��Wrap=�6Z   $��TOTAL��6n   $	��Top=�6{   $��22��6�   $��45��6�   �� 5   
   -   5         ��Name$ 	txtPrecio��5      $
��Left=�6%   $��22��6@   $��144,124,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $��91��6�   �� 5   
   -   5        $ txtCantidad��5      $
��Left=�6'   $��22��6B   $��144,158,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $��91��6�   6�   �� 5   
   -   5        $ txtTotal��5      $
��Left=�6$   $��22��6?   $��144,198,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��91��6�   �� 5   
   -   5         ��Name$ cb��5      $
��Left=�6   $��
144,91,0,0q�6:   $	��Top=�6N   $��91��6f    �� DisplayMemberPath$ Nombre��6q    �� SelectedValuePath$ Id��5       �� SelectedValue 5      �� *
Inventario+ �� Mode$ OneWay=�5   (   �� 5   
   -   5        	 ��Name$	 	btnVender��5      $��VENDER��6$   $
��Left=�65   $��39��6P   $��
34,260,0,0q�6\   $	��Top=�6p   $	��201��6�   6�   �� 5   
   $
��Left=�6   $��22��6.   $��
317,91,0,0q�6:   $
 Wrap=�6N   $��Cantidad Actual��6b   $	��Top=�6y   $	��107��6�   �� 5   
   -   5        $ txtCantidadActual��5      $
��Left=�6-   $��22��6H   $��325,124,0,0q�6T   $
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $��91��6�   5      5      
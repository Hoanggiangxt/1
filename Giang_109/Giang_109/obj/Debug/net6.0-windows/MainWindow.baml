   M S B A M L   `   `   `  ����D  @Giang_109, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Giang_109	Giang_109  5   	       Giang_109.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Giang_109     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   6.   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   .+�5   
   �� $��0��6   $��0��6!   $��2��61    
  header#��[  6E   Quản lý sản phẩm6w   �� 5   
   $��1��6   $��0��6    	 label#��[ 6-   .��6L   Mã sản phẩm6Y   �� 5   
   -   5        $��txtmasp��5   /   $��1��6   $��1��6     textbox#��[ 6>   6a   �� 5   
   $��2��6   $��0��6   #��[ 6-   .��6L   Tên sản phẩm6Z   �� 5   
   -   5        $��txttensp��5   /   $��2��6   $��1��6   #��[ 6?   6b   �� 5    
   $��3��6   $��0��6   #��[ 6-   .��6L   Số lượng6V   �� 5!   
   -   5        $��
txtsoluong��5!   /   $��3��6   $��1��6   #��[ 6A   6d   �� 5#   
   $��4��6   $��0��6   #��[ 6-   .��6L   
Đơn giá6U   �� 5$   
   -   5        $��	txtdongia��5$   /   $��4��6   $��1��6   #��[ 6@   6c   �� 5&   
   $��5��6   $��0��6   #��[ 6-   .��6L   
Mã loại6U   �� 5'   
   -   5         ��Name$ cbmaloai��5'      $��5��6%   $��1��62     combobox#��[ 6C   5)      &   System.Windows.Controls.DataGrid  5*   
   -   5        $��
dgDanhsach��5*      $��6��6%   $��0��62   $��2��6B      AutoGenerateColumns$ False��6V     grid#��[ 6�      Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã sản phẩm��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *msp+6T     5-      $ Tên sản phẩm��6%    6;   �� *tensp+6W     5.      $ Tên loại sản phẩm��6%    6@   �� *tenlsp+6]     5/      $ 
Đơn giá��6%    66   �� *dongia+6S     50      $ Số lượng��6%    67   �� *	soluong+6U     51      $ Thành tiền��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 69    6C   �� *	thanhtien+	   	CellStyle	 52      �� 53      
 �� 
TargetType*  $System.Windows.Controls.DataGridCell"
  6    .�54      ��  �� Property � �� �� Value
 �  ��6I   55      57      59      �� 5;   
   $��7��6   $��0��6#   $��2��63    �� Orientation$ 
Horizontal=�6G   $��Center=�6`   .+�5<      �� -   5        $��btnthem��5<       
 button#��[ 6$   .��6Z   Thêm6`   �� 5=      -   5        $��btnsua��5=      #��[ 6#   .��6X   Sửa6]   �� 5>      -	   5        $��btnxoa��5>      #��[ 6#   .��6X   Xóa6]   �� 5?      -
   5        $��btntim��5?      #��[ 6#   .��6X   Tìm6]   5@      5B      5C      
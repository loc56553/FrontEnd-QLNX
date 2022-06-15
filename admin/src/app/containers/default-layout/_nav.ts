import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    title: true,
    name: 'Quản lý'
  },
  {
    name: 'Quản Nhân Viên',
    url: '/NhanVien',
    iconComponent: { name: 'cil-user' }
  },
  {
    name: 'Quản Lý Chức Vụ',
    url: '/ChucVu',
    iconComponent: { name: 'cil-people' }
  },
  {
    name: 'Quản Lý Loại Xe',
    url: '/LoaiXe',
    iconComponent: { name: 'cil-locomotive' }
  },
  {
    name: 'Quản Lý Xe',
    url: '/Xe',
    iconComponent: { name: 'cil-car-alt' }
  },
  {
    name: 'Quản Tuyến Đường',
    url: '/TuyenDuong',
    iconComponent: { name: 'cil-compress' }
  },
  {
    name: 'Quản Chuyến Xe',
    url: '/ChuyenXe',
    iconComponent: { name: 'cil-garage' }
  },
  {
    name: 'Đặt Vé',
    url: '/VeXe',
    iconComponent: { name: 'cil-rectangle'}
  },
  {
    name: 'Vé Xe',
    url: '/VeXeView',
    //iconComponent: { name: 'cil-rectangle'}
  },
];

import { FormVeXeViewComponent } from './views/FormVeXeView/FormVeXeView.component';
import { FormVeXeViewModule } from './views/FormVeXeView/FormVeXeView.module';

import { FormClientModule } from './views/Form-Client/Form-Client.module';
import { ChuyenXeModule } from './views/ChuyenXe/ChuyenXe.module';
import { TuyenDuongModule } from './views/TuyenDuong/TuyenDuong.module';
import { XeModule } from './views/Xe/Xe.module';
import { LoaiXeModule } from './views/LoaiXe/LoaiXe.module';
import { ChucVuModule } from './views/ChucVu/chucvu.module'
import { UserModule } from './views/user/user.module';
import { VeXeModule } from './views/VeXe/VeXe.module';

import { DataService } from './Services/data.service';
import { ServerHttpService } from './Services/server-http.service';
import { NgModule } from '@angular/core';
import { HashLocationStrategy, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { BrowserModule, Title } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms'; 
import { FormsModule } from '@angular/forms'
import {
  PERFECT_SCROLLBAR_CONFIG,
  PerfectScrollbarConfigInterface,
  PerfectScrollbarModule,
} from 'ngx-perfect-scrollbar';
import {HttpClientModule} from '@angular/common/http';
// Import routing module
import { AppRoutingModule } from './app-routing.module';

// Import app component
import { AppComponent } from './app.component';

// Import containers
import {
  DefaultFooterComponent,
  DefaultHeaderComponent,
  DefaultLayoutComponent,
} from './containers';

import {
  AvatarModule,
  BadgeModule,
  BreadcrumbModule,
  ButtonGroupModule,
  ButtonModule,
  CardModule,
  DropdownModule,
  FooterModule,
  FormModule,
  GridModule,
  HeaderModule,
  ListGroupModule,
  NavModule,
  ProgressModule,
  SharedModule,
  SidebarModule,
  TabsModule,
  UtilitiesModule,
} from '@coreui/angular';

import { IconModule, IconSetService } from '@coreui/icons-angular';
import { UserComponent } from './views/user/user.component';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true,
};

const APP_CONTAINERS = [
  DefaultFooterComponent,
  DefaultHeaderComponent,
  DefaultLayoutComponent,
];

@NgModule({
  declarations: [AppComponent, ...APP_CONTAINERS, UserComponent ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AvatarModule,
    BreadcrumbModule,
    FooterModule,
    FormModule,
    DropdownModule,
    GridModule,
    HeaderModule,
    SidebarModule,
    IconModule,
    PerfectScrollbarModule,
    NavModule,
    ButtonModule,
    UtilitiesModule,
    ButtonGroupModule,
    ReactiveFormsModule,
    SidebarModule,
    SharedModule,
    TabsModule,
    ListGroupModule,
    ProgressModule,
    BadgeModule,
    ListGroupModule,
    CardModule,
    HttpClientModule,
    FormsModule,
    UserModule,
    ChucVuModule,
    LoaiXeModule,
    XeModule,
    TuyenDuongModule,
    ChuyenXeModule,
    VeXeModule,
    FormClientModule,
    FormVeXeViewModule
  ],
  providers: [
    {
      provide: LocationStrategy,
      useClass: HashLocationStrategy,
    },
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG,
    },
    IconSetService,
    ServerHttpService,
    DataService,
    Title
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
}


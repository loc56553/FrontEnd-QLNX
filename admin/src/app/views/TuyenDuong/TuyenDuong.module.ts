import { AddTuyenDuongComponent } from './../Add-TuyenDuong/Add-TuyenDuong.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TuyenDuongComponent } from './TuyenDuong.component';
import {
  ButtonGroupModule,
  ButtonModule,
  CardModule,
  FormModule,
  GridModule,
  NavModule,
  ProgressModule,
  TableModule,
  TabsModule
} from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { ChartjsModule } from '@coreui/angular-chartjs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
@NgModule({
  imports: [
    CommonModule,
    ButtonGroupModule,
     ButtonModule,
    CardModule,
    FormModule,
    GridModule,
    NavModule,
    ProgressModule,
    TableModule,
    TabsModule,
    IconModule,
    ChartjsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [TuyenDuongComponent,AddTuyenDuongComponent]
})
export class TuyenDuongModule { }

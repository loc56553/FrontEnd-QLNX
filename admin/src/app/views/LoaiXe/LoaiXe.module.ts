import { AddLoaiXeComponent } from './../Add-LoaiXe/Add-LoaiXe.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaiXeComponent } from './LoaiXe.component';

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
    FormsModule,
    ReactiveFormsModule,
    ChartjsModule,
    IconModule,
  ],
  declarations: [LoaiXeComponent , AddLoaiXeComponent]
})
export class LoaiXeModule { }


import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChucVuComponent } from './chucvu.component';
import { AddChucVuComponent } from '../Add-ChucVu/Add-ChucVu.component';
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
    CardModule,
    NavModule,
    IconModule,
    TabsModule,
    CommonModule,
    GridModule,
    ProgressModule,
    ReactiveFormsModule,
    ButtonModule,
    FormModule,
    ButtonModule,
    ButtonGroupModule,
    ChartjsModule,
    TableModule,
    FormsModule
  ],
  declarations: [ChucVuComponent,AddChucVuComponent]
})
export class ChucVuModule { }

import { FormDatVeClientComponent } from './../FormDatVeClient/FormDatVeClient.component';
import { AddVeXeClientComponent } from './../Add-VeXeClient/Add-VeXeClient.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormClientComponent } from './Form-Client.component';
import { FormDatVeComponent } from './../FormDatVe/FormDatVe.component';

import { AddVeXeComponent } from './../Add-VeXe/Add-VeXe.component';
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
  declarations: [FormClientComponent , AddVeXeClientComponent , FormDatVeClientComponent]
})
export class FormClientModule { }

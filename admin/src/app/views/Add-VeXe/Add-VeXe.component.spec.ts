/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddVeXeComponent } from './Add-VeXe.component';

describe('AddVeXeComponent', () => {
  let component: AddVeXeComponent;
  let fixture: ComponentFixture<AddVeXeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddVeXeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddVeXeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddChuyenXeComponent } from './Add-ChuyenXe.component';

describe('AddChuyenXeComponent', () => {
  let component: AddChuyenXeComponent;
  let fixture: ComponentFixture<AddChuyenXeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddChuyenXeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddChuyenXeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

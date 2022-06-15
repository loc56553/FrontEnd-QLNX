/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddTuyenDuongComponent } from './Add-TuyenDuong.component';

describe('AddTuyenDuongComponent', () => {
  let component: AddTuyenDuongComponent;
  let fixture: ComponentFixture<AddTuyenDuongComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddTuyenDuongComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTuyenDuongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

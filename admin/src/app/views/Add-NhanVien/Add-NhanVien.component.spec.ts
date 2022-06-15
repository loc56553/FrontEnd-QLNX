/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddNhanVienComponent } from './Add-NhanVien.component';

describe('AddNhanVienComponent', () => {
  let component: AddNhanVienComponent;
  let fixture: ComponentFixture<AddNhanVienComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddNhanVienComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNhanVienComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

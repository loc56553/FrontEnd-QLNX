/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddChucVuComponent } from './Add-ChucVu.component';

describe('AddChucVuComponent', () => {
  let component: AddChucVuComponent;
  let fixture: ComponentFixture<AddChucVuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddChucVuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddChucVuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

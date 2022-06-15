/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddXeComponent } from './Add-Xe.component';

describe('AddXeComponent', () => {
  let component: AddXeComponent;
  let fixture: ComponentFixture<AddXeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddXeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddXeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeLoggedUserComponent } from './home-logged-user.component';

describe('HomeLoggedUserComponent', () => {
  let component: HomeLoggedUserComponent;
  let fixture: ComponentFixture<HomeLoggedUserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HomeLoggedUserComponent]
    });
    fixture = TestBed.createComponent(HomeLoggedUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

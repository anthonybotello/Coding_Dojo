import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorErrorComponent } from './author-error.component';

describe('AuthorErrorComponent', () => {
  let component: AuthorErrorComponent;
  let fixture: ComponentFixture<AuthorErrorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuthorErrorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthorErrorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

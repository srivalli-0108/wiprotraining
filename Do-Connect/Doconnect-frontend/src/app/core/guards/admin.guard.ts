import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private router: Router) {}

  canActivate(): boolean {
    const token = localStorage.getItem('token');
    const role = localStorage.getItem('role'); // Assuming you store user role

    if (token && role === 'admin') {
      return true;
    }

    // Redirect to login or unauthorized page
    this.router.navigate(['/login']);
    return false;
  }
}

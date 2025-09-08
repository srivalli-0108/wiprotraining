// src/app/shared/directives/highlight.directive.ts
import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({ selector: '[appHighlight]' })
export class HighlightDirective {
  constructor(private el: ElementRef) {}

  @HostListener('mouseenter')
  onEnter() {
    this.el.nativeElement.style.backgroundColor = 'yellow';
  }

  @HostListener('mouseleave')
  onLeave() {
    this.el.nativeElement.style.backgroundColor = '';
  }
}

import { Directive, Renderer2, ElementRef, Input, HostListener, HostBinding } from '@angular/core';
import { AngularWaitBarrier } from 'blocking-proxy/built/lib/angular_wait_barrier';

@Directive({
  selector: '[appDropdown]'
})
export class DropdownDirective {
  // @HostBinding('class.show') isShown = false;

  constructor(private renderer: Renderer2, private elRef: ElementRef) { }

  @HostListener('document:click', ['$event']) toggleOpen(event: Event) {
    this.elRef.nativeElement.contains(event.target) ? this.toggle() : this.clear();
  }

  toggle() {
    const elements = Array.from(this.elRef.nativeElement.children);
    const dropdown = elements.find((e: HTMLElement) => e.classList.contains('dropdown-menu')) as HTMLElement;
    dropdown.classList.contains('show') ?
      this.renderer.removeClass(dropdown, 'show') :
      this.renderer.addClass(dropdown, 'show');
  }

  clear() {
    const elements = Array.from(this.elRef.nativeElement.children);
    const dropdown = elements.find((e: HTMLElement) => e.classList.contains('dropdown-menu')) as HTMLElement;
    this.renderer.removeClass(dropdown, 'show');
  }

  // @HostListener('document:click', ['$event']) toggleOpen(event: Event) {
  //   this.isShown = this.elRef.nativeElement.contains(event.target) ? !this.isShown : false;
  // }
}

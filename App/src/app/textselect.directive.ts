import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appTextselect]'
})
export class TextselectDirective {

  constructor(private el: ElementRef<HTMLInputElement>) {}

  @HostListener('focus', ['$event.target'])
  onFocus(target: HTMLInputElement): void {
    target.select();
  }

}

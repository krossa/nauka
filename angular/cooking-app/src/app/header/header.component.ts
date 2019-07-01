import { Component, Output, EventEmitter, OnInit } from '@angular/core';

@Component({
    selector: 'app-header',
    templateUrl: 'header.component.html'
})
export class HeaderComponent implements OnInit {
    @Output() componentSelected = new EventEmitter<string>();
    component = 'recipes';

    ngOnInit() {
        this.componentSelected.emit(this.component);
    }

    onSelectComponent(component: string) {
        this.component = component;
        this.componentSelected.emit(component);
    }
}

import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterOutlet,RouterLink],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent implements AfterViewInit {
  @ViewChild('toggleBtn') toggleBtn!: ElementRef;

  ngAfterViewInit() {
    this.toggleBtn.nativeElement.addEventListener("click", () => {
      document.querySelector("#sidebar")?.classList.toggle("expand");
    });
  }
}
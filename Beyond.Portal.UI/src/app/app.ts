import { ChangeDetectorRef, Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { MatProgressBarModule, ProgressBarMode } from '@angular/material/progress-bar';
import { TodoList } from '../models/todo-list';
import { CommonModule, DatePipe } from '@angular/common';
import { TodoItem } from '../models/todo-item';
import { Progression } from '../models/progression';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatProgressBarModule, CommonModule],
  providers: [DatePipe],
  templateUrl: './app.html',
  styleUrls: ['./app.scss']
})
export class App {
  protected title = 'Beyond.Portal.UI';

  todoList: TodoList = new TodoList([]);

  mode: ProgressBarMode = 'determinate';

  constructor(
    private http: HttpClient,
    private cd: ChangeDetectorRef,
    private datePipe: DatePipe
  ) {}

  reload(): void {
    this.http.get<TodoList>('http://localhost:5197/api/todolist').subscribe({
      next: (todoListResponse: TodoList) => {
        this.todoList = todoListResponse;
        this.todoList.items.forEach((item) => {
          item.progressions = item.progressions?.sort((a, b) => (b.actionCompletedDateTime as any) - (a.actionCompletedDateTime as any)) || [];
        });
        this.cd.markForCheck();
      }
    });
  }

  formatHeader(todoItem: TodoItem): string {
    return `${todoItem.id}) ${todoItem.title} - ${todoItem.description} (${todoItem.category}) Completed: ${todoItem.isCompleted}`;
  }

  formatProgression(progressions: Progression[], currentIndex: number): string {
    return `${this.datePipe.transform(progressions[currentIndex].actionCompletedDateTime, 'short')} - ${this.getProgressionValue(progressions, currentIndex)}%`;
  }

  getProgressionValue(progressions: Progression[], currentIndex: number): number {
    var progressionValue = 0;
    for (var i = 0; i <= currentIndex; i++)
    {
      progressionValue += progressions[i].completedPercentage;
    }
    return progressionValue;
  }
}

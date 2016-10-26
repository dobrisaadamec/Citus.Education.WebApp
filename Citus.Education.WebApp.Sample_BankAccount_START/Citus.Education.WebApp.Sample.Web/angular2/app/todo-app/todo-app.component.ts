import { Component } from '@angular/core';
import { Todo } from './todo';
import { TodoService } from './todo.service';

@Component({
    moduleId: module.id,
    selector: 'todo-app',
    templateUrl: 'todo-app.component.html',
    styleUrls: ['todo-app.component.css'],
    providers: [TodoService]
})
export class TodoAppComponent {

    newTodo: Todo = new Todo();
    todos: Todo[];
    errorMessage: string;

    constructor(private todoService: TodoService) {
        this.todoService.getAllTodos()
            .subscribe(
            tds => this.todos = tds,
            error => this.errorMessage = <any>error);

    }

    addTodo() {
        this.todoService.addTodo(this.newTodo);
        this.newTodo = new Todo();
    }

    toggleTodoComplete(todo: Todo) {
        this.todoService.toggleTodoComplete(todo);
    }

    removeTodo(todo: Todo) {
        this.todoService.deleteTodoById(todo.id);
    }

    //get todos() {
    //    return this.todoService.getAllTodos();
    //}
}

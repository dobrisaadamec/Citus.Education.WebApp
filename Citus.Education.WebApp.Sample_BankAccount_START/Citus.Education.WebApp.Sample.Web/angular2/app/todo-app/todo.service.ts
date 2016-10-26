import { Injectable } from '@angular/core';
import { Todo } from './todo';

import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';


@Injectable()
export class TodoService {

    // Placeholder for last id so we can simulate
    // automatic incrementing of id's
    lastId: number = 0;
    private todosUrl = 'api/todo/todos.json';

    // Placeholder for todo's
    todos: Todo[] = [];

    constructor(private _http: Http) { }

    // Simulate POST /todos
    addTodo(todo: Todo): TodoService {
        if (!todo.id) {
            todo.id = ++this.lastId;
        }
        this.todos.push(todo);
        return this;
    }

    // Simulate DELETE /todos/:id
    deleteTodoById(id: number): TodoService {
        this.todos = this.todos
            .filter(todo => todo.id !== id);
        return this;
    }

    // Simulate PUT /todos/:id
    updateTodoById(id: number, values: Object = {}): Todo {
        let todo = this.getTodoById(id);
        if (!todo) {
            return null;
        }
        Object.assign(todo, values);
        return todo;
    }

    //// Simulate GET /todos
    //getAllTodos(): Todo[] {
    //    return this.todos;
    //}
    getAllTodos(): Observable<Todo[]> {
        return this._http.get(this.todosUrl)
            .map((response: Response) => <Todo[]>response.json())
            .do(data => console.log("All: " + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }


    // Simulate GET /todos/:id
    getTodoById(id: number): Todo {
        return this.todos
            .filter(todo => todo.id === id)
            .pop();
    }

    // Toggle todo complete
    toggleTodoComplete(todo: Todo) {
        let updatedTodo = this.updateTodoById(todo.id, {
            complete: !todo.complete
        });
        return updatedTodo;
    }
}

import { Component, TemplateRef, OnInit } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import {
  TodoListsClient, TodoItemsClient,
  TodoListDto, TodoItemDto, LookupDto,
  CreateTodoListCommand, UpdateTodoListCommand,
  CreateTodoItemCommand, UpdateTodoItemCommand, UpdateTodoItemDetailCommand
} from '../web-api-client';

@Component({
  selector: 'app-todo-component',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.scss']
})
export class TodoComponent implements OnInit {
  debug = false;
  lists: TodoListDto[] = [];
  priorityLevels: LookupDto[] = [];
  selectedList: TodoListDto = new TodoListDto();
  selectedItem: TodoItemDto = new TodoItemDto();
  newListEditor: any = {};
  listOptionsEditor: any = {};
  itemDetailsEditor: any = {};
  newListModalRef: BsModalRef = new BsModalRef();
  listOptionsModalRef: BsModalRef = new BsModalRef();
  deleteListModalRef: BsModalRef = new BsModalRef();
  itemDetailsModalRef: BsModalRef = new BsModalRef();

  constructor(
    private listsClient: TodoListsClient,
    private itemsClient: TodoItemsClient,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.listsClient.todoLists_GetTodoLists().subscribe(
      result => {
        this.lists = result.lists as TodoListDto[];
        console.log(this.lists);
        this.priorityLevels = result.priorityLevels as LookupDto[];
        if (this.lists.length) {
          this.selectedList = this.lists[0];
        }
      },
      error => console.error(error)
    );
  }

  // Lists
  remainingItems(list: TodoListDto): number {
    return list.items!.filter(t => !t.done).length;
  }

  showNewListModal(template: TemplateRef<any>): void {
    this.newListModalRef = this.modalService.show(template);
    setTimeout(() => (document.getElementById('title') as HTMLInputElement).focus(), 250);
  }

  newListCancelled(): void {
    this.newListModalRef.hide();
    this.newListEditor = {};
  }

  addList(): void {
    const list = {
      id: 0,
      title: this.newListEditor.title,
      items: [],
      init: () => 0,
      toJSON: () => 0
    } as TodoListDto;

    this.listsClient.todoLists_CreateTodoList(list as CreateTodoListCommand).subscribe(
      result => {
        list.id = result;
        this.lists.push(list);
        this.selectedList = list;
        this.newListModalRef.hide();
        this.newListEditor = {};
      },
      error => {
        const errors = JSON.parse(error.response).errors;

        if (errors && errors.Title) {
          this.newListEditor.error = errors.Title[0];
        }

        setTimeout(() => (document.getElementById('title') as HTMLInputElement).focus(), 250);
      }
    );
  }

  showListOptionsModal(template: TemplateRef<any>) {
    this.listOptionsEditor = {
      id: this.selectedList.id,
      title: this.selectedList.title
    };

    this.listOptionsModalRef = this.modalService.show(template);
  }

  updateListOptions() {
    const list = this.listOptionsEditor as UpdateTodoListCommand;
    this.listsClient.todoLists_UpdateTodoList(this.selectedList.id as number, list).subscribe(
      () => {
        (this.selectedList.title = this.listOptionsEditor.title),
          this.listOptionsModalRef.hide();
        this.listOptionsEditor = {};
      },
      error => console.error(error)
    );
  }

  confirmDeleteList(template: TemplateRef<any>) {
    this.listOptionsModalRef.hide();
    this.deleteListModalRef = this.modalService.show(template);
  }

  deleteListConfirmed(): void {
    this.listsClient.todoLists_DeleteTodoList(this.selectedList.id as number).subscribe(
      () => {
        this.deleteListModalRef.hide();
        this.lists = this.lists.filter(t => t.id !== this.selectedList.id);
        this.selectedList = this.lists.length ? this.lists[0] : null!;
      },
      error => console.error(error)
    );
  }

  // Items
  showItemDetailsModal(template: TemplateRef<any>, item: TodoItemDto): void {
    this.selectedItem = item;
    this.itemDetailsEditor = {
      ...this.selectedItem
    };

    this.itemDetailsModalRef = this.modalService.show(template);
  }

  updateItemDetails(): void {
    const item = this.itemDetailsEditor as UpdateTodoItemDetailCommand;
    this.itemsClient.todoItems_UpdateTodoItemDetail((this.selectedItem as TodoItemDto).id as number, item).subscribe(
      () => {
        if ((this.selectedItem as TodoItemDto).listId !== this.itemDetailsEditor.listId) {
          this.selectedList.items = (this.selectedList.items as TodoItemDto[]).filter(
            i => i.id !== (this.selectedItem as TodoItemDto).id
          );
          const listIndex = this.lists.findIndex(
            l => l.id === this.itemDetailsEditor.listId
          );
          (this.selectedItem as TodoItemDto).listId = this.itemDetailsEditor.listId;
          (this.lists[listIndex].items as TodoItemDto[]).push((this.selectedItem as TodoItemDto));
        }

        (this.selectedItem as TodoItemDto).priority = this.itemDetailsEditor.priority;
        (this.selectedItem as TodoItemDto).note = this.itemDetailsEditor.note;
        this.itemDetailsModalRef.hide();
        this.itemDetailsEditor = {};
      },
      error => console.error(error)
    );
  }

  addItem() {
    const item = {
      id: 0,
      listId: this.selectedList.id,
      priority: this.priorityLevels[0].id,
      title: '',
      done: false
    } as TodoItemDto;

    (this.selectedList.items as TodoItemDto[]).push(item);
    const index = (this.selectedList.items as TodoItemDto[]).length - 1;
    this.editItem(item, 'itemTitle' + index);
  }

  editItem(item: TodoItemDto, inputId: string): void {
    this.selectedItem = item;
    setTimeout(() => (document.getElementById(inputId) as HTMLInputElement).focus(), 100);
  }

  updateItem(item: TodoItemDto, pressedEnter: boolean = false): void {
    const isNewItem = item.id === 0;

    if (!(item.title as string).trim()) {
      this.deleteItem(item);
      return;
    }

    if (item.id === 0) {
      this.itemsClient
        .todoItems_CreateTodoItem({ title: item.title, listId: this.selectedList.id } as CreateTodoItemCommand)
        .subscribe(
          result => {
            item.id = result;
          },
          error => console.error(error)
        );
    } else {
      this.itemsClient.todoItems_UpdateTodoItem(item.id as number, item as UpdateTodoItemCommand).subscribe(
        () => console.log('Update succeeded.'),
        error => console.error(error)
      );
    }

    this.selectedItem = null!;

    if (isNewItem && pressedEnter) {
      setTimeout(() => this.addItem(), 250);
    }
  }

  deleteItem(item: TodoItemDto) {
    if (this.itemDetailsModalRef) {
      this.itemDetailsModalRef.hide();
    }

    if (item.id === 0) {
      const itemIndex = (this.selectedList.items as TodoItemDto[]).indexOf(this.selectedItem as TodoItemDto);
      (this.selectedList.items as TodoItemDto[]).splice(itemIndex, 1);
    } else {
      this.itemsClient.todoItems_DeleteTodoItem(item.id as number).subscribe(
        () =>
        (this.selectedList.items = (this.selectedList.items as TodoItemDto[]).filter(
          t => t.id !== item.id
        )),
        error => console.error(error)
      );
    }
  }
}

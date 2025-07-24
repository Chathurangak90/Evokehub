import { Component, OnInit } from '@angular/core';
import { Book } from '../../models/book.model';
import { BookService } from '../../services/book.service';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order.model';

@Component({
  selector: 'app-book-list',
  standalone: false,
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent implements OnInit {
  books: Book[] = [];
  filteredBooks: Book[] = [];
  searchTerm = '';
  storeFilter: string | null = null;

  //sorting option: 'title', 'price', or 'author'
  sortBy: 'title' | 'price' | 'author' = 'title';

  currentPage = 1;
  pageSize = 10;

  // Inject the OrderService and BookService to handle book retrieval and order placement
  constructor(private bookService: BookService, private orderService: OrderService) { }

  // Called once when the component is initialized
  ngOnInit(): void {
    this.loadBooks();
  }


  loadBooks(): void {
    this.bookService.getBooks(this.currentPage, this.pageSize).subscribe((data) => {
      this.books = data;
      this.applyFilters();
    });
  }

  //Filters and sorts the book list
  applyFilters(): void {
    let result = [...this.books];
    if (this.searchTerm) {
      result = result.filter((b) => b.title.toLowerCase().includes(this.searchTerm.toLowerCase()));
    }
    if (this.storeFilter) {
      result = result.filter((b) => b.store === this.storeFilter);
    }
    // Apply sorting logic
    result.sort((a, b) => {
      if (this.sortBy === 'price') return a.price - b.price;
      return a[this.sortBy].localeCompare(b[this.sortBy]);
    });
    this.filteredBooks = result;
  }

  //Called when a store filter button is clicked.
  //Updates the current store filter and reapplies filtering logic.
  //@param store Store name ('Greta', 'Peter', or null for All)
  setStoreFilter(store: string | null): void {
    this.storeFilter = store;
    this.applyFilters();
  }

  //Called when the "Buy" button is clicked for a boo
  onBuy(order: Order): void {
    this.orderService.placeOrder({
      id: order.id,
      orderNumber: '',
      title: order.title,
      price: order.price,
      store: order.store
    }).subscribe({
      next: (response) => {
        alert('Order placed successfully!');
      },
      error: (err) => {
        const apiMessage = err?.error?.message || 'Failed to place order';
        alert(apiMessage);
      }
    });
  }

  nextPage(): void {
    this.currentPage++;
    this.loadBooks();
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadBooks();
    }
  }

}

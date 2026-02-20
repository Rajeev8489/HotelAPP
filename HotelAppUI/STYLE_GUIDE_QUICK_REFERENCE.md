# Style Guide - Quick Reference

## 🎨 Colors

### Primary
```css
--color-primary: #1a73e8        /* Trust Blue */
--color-primary-dark: #1557b0    /* Hover */
--color-accent: #ff6b35          /* CTA Orange */
--color-accent-dark: #e55a2b     /* Hover */
```

### Neutrals
```css
--color-charcoal: #2c2c2c        /* Text Primary */
--color-slate: #6b7280           /* Text Secondary */
--color-cloud: #f5f7fa           /* Backgrounds */
--color-white: #ffffff           /* Cards */
```

### Trust & Premium
```css
--color-gold: #fbbf24            /* Premium Badge */
--color-rating: #ffc107          /* Stars */
--color-success: #10b981          /* Verified */
```

## 📝 Typography

### Font Stack
```css
font-family: -apple-system, BlinkMacSystemFont, 'SF Pro Display', 
             'Segoe UI', 'Roboto', 'Helvetica Neue', Arial, sans-serif;
```

### Sizes
```css
Hero:   40px (2.5rem)  /* Landing */
H1:    36px (2.25rem) /* Page Title */
H2:    30px (1.875rem)/* Section */
H3:    24px (1.5rem)   /* Card Title */
H4:    20px (1.25rem)  /* Subheading */
Body:  16px (1rem)     /* Default */
Small: 14px (0.875rem) /* Labels */
Tiny:  12px (0.75rem)  /* Badges */
```

### Weights
```css
Normal:    400
Medium:    500
Semibold:  600
Bold:      700
```

## 📏 Spacing

### Scale (8px base)
```css
4px   - Tight (icons)
8px   - Small (elements)
12px  - Default (cards)
16px  - Standard (margins)
24px  - Large (sections)
32px  - Extra Large
48px  - Hero
```

## 🔘 Buttons

### Primary CTA
```css
.btn-accent {
  height: 52px;
  padding: 16px 24px;
  border-radius: 16px;
  background: linear-gradient(135deg, #ff6b35, #e55a2b);
  color: white;
  font-weight: 700;
  font-size: 16px;
  box-shadow: 0 4px 12px rgba(0,0,0,0.1);
}
```

### Secondary
```css
.btn-primary {
  height: 52px;
  padding: 16px 24px;
  border-radius: 16px;
  background: linear-gradient(135deg, #1a73e8, #1557b0);
  color: white;
  font-weight: 600;
}
```

### Outline
```css
.btn-outline {
  height: 52px;
  padding: 16px 24px;
  border-radius: 16px;
  background: transparent;
  border: 2px solid #1a73e8;
  color: #1a73e8;
}
```

## 🎴 Cards

### Hotel Card
```css
.card {
  border-radius: 24px;
  box-shadow: 0 2px 8px rgba(0,0,0,0.08);
  overflow: hidden;
  background: white;
}

.card-image {
  height: 200px;
  object-fit: cover;
}

.card-body {
  padding: 20px;
}
```

## ⭐ Rating Display

```html
<div class="rating">
  <div class="rating-stars">⭐⭐⭐⭐⭐</div>
  <span class="rating-value">4.5</span>
  <span class="rating-count">(128 reviews)</span>
</div>
```

## 🏷️ Badges

### Premium
```html
<span class="badge-premium">
  <i class="fas fa-crown"></i> Premium
</span>
```

### Verified
```html
<span class="badge-verified">
  <i class="fas fa-check-circle"></i> Verified
</span>
```

## 💰 Price Display

```html
<div class="price">
  <div class="price-current">$199</div>
  <div class="price-period">per night</div>
</div>
```

## 📱 Layout

### Mobile Container
```css
.mobile-container {
  max-width: 100%;
  padding: 16px;
}

@media (min-width: 768px) {
  .mobile-container {
    max-width: 600px;
    padding: 24px;
  }
}
```

### Header
```css
.mobile-header {
  height: 64px;
  position: sticky;
  top: 0;
  background: white;
  border-bottom: 1px solid #f5f7fa;
  box-shadow: 0 2px 4px rgba(0,0,0,0.08);
}
```

### Bottom Nav
```css
.bottom-nav {
  height: 72px;
  position: fixed;
  bottom: 0;
  background: white;
  border-top: 1px solid #f5f7fa;
  box-shadow: 0 -2px 8px rgba(0,0,0,0.08);
}
```

## 🎯 CTAs

### Book Now Button
```html
<a href="#" class="btn btn-accent btn-full">
  <i class="fas fa-calendar-check me-2"></i>Book Now
</a>
```

### View Details
```html
<a href="#" class="btn btn-outline">
  View Details
</a>
```

## 🔍 Search Bar

```html
<div class="search-bar">
  <i class="fas fa-search search-icon"></i>
  <input type="text" class="search-input" placeholder="Search..." />
</div>
```

## 🎨 Filters

```html
<div class="filter-chips">
  <button class="filter-chip active">All</button>
  <button class="filter-chip">Premium</button>
  <button class="filter-chip">Budget</button>
</div>
```

## 📐 Grid System

### 2-Column Grid
```css
.grid-2 {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 16px;
}
```

### Responsive Grid
```css
@media (min-width: 768px) {
  .hotel-list {
    grid-template-columns: repeat(2, 1fr);
  }
}
```

## ✨ Animations

### Fade In
```css
.animate-fade-in {
  animation: fadeIn 0.3s ease-out;
}
```

### Slide Up
```css
.animate-slide-up {
  animation: slideUp 0.4s ease-out;
}
```

## 🎯 Trust Elements

### Rating Stars
```html
<div class="rating-stars" style="color: #ffc107;">
  <i class="fas fa-star"></i>
  <i class="fas fa-star"></i>
  <i class="fas fa-star"></i>
  <i class="fas fa-star"></i>
  <i class="fas fa-star-half-alt"></i>
</div>
```

### Social Proof
```html
<div class="flex-between">
  <span>⭐ 4.5 (128 reviews)</span>
  <span class="badge-verified">Verified</span>
</div>
```

## 📱 Responsive Breakpoints

```css
/* Mobile First */
@media (min-width: 768px) { /* Tablet */ }
@media (min-width: 1024px) { /* Desktop */ }
```

## 🎨 Shadows

```css
--shadow-sm: 0 2px 4px rgba(0,0,0,0.08);
--shadow-md: 0 4px 12px rgba(0,0,0,0.1);
--shadow-lg: 0 8px 24px rgba(0,0,0,0.12);
--shadow-card: 0 2px 8px rgba(0,0,0,0.08);
```

## 🔤 Text Utilities

```css
.text-center { text-align: center; }
.text-right { text-align: right; }
.text-primary { color: #1a73e8; }
.text-secondary { color: #6b7280; }
.text-muted { color: #9ca3af; }
```

## 📦 Flex Utilities

```css
.flex { display: flex; }
.flex-between { display: flex; justify-content: space-between; align-items: center; }
.flex-center { display: flex; align-items: center; justify-content: center; }
.gap-2 { gap: 8px; }
.gap-4 { gap: 16px; }
```

## 🎯 Conversion Best Practices

1. **CTAs**: Use accent orange (#ff6b35)
2. **Price**: Large, bold, prominent
3. **Trust**: Ratings + badges everywhere
4. **Urgency**: "Only X left" badges
5. **Social Proof**: Review counts visible

---

**Quick Copy-Paste Reference for Developers** 🚀

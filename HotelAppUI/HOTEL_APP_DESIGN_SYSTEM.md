# HotelAppUI – Luxury Design System

## Design Philosophy

The interface is designed to feel **elegant**, **premium**, and **trustworthy** while remaining **simple and globally appealing**. Every color, type choice, and spacing decision supports perceived quality and booking conversion.

---

## 1. Color System

### Primary Palette

| Role | HEX | Usage | Psychological Impact |
|------|-----|--------|----------------------|
| **Primary** | `#0D9488` | Main actions, links, key UI | **Teal** – Calm, trust, reliability; evokes water and travel; premium without being cold. |
| **Primary Hover** | `#0F766E` | Hover states | Deeper teal for clear feedback. |
| **Primary Light** | `#CCFBF1` | Backgrounds, badges | Soft tint for emphasis areas. |

### Secondary Palette

| Role | HEX | Usage | Psychological Impact |
|------|-----|--------|----------------------|
| **Secondary** | `#1E293B` | Headers, strong text, nav | **Slate/Navy** – Sophistication, depth, authority; reads as “serious” and professional. |
| **Secondary Muted** | `#334155` | Subheadings | Softer hierarchy. |

### Accent (Conversion & Luxury)

| Role | HEX | Usage | Psychological Impact |
|------|-----|--------|----------------------|
| **Accent** | `#B45309` | CTAs (Book Now, Reserve) | **Warm amber** – Urgency, warmth, reward; encourages action and feels premium. |
| **Accent Hover** | `#92400E` | CTA hover | Stronger emphasis. |
| **Gold** | `#CA8A04` | Badges, ratings, highlights | **Gold** – Luxury, quality, success; universal symbol of premium. |

### Backgrounds

| Role | HEX | Usage |
|------|-----|--------|
| **Background** | `#FAFAF9` | Page background (warm off-white) |
| **Surface** | `#FFFFFF` | Cards, modals, sheets |
| **Surface Elevated** | `#F5F5F4` | Inputs, secondary panels |
| **Overlay** | `rgba(30, 41, 59, 0.4)` | Modals, scrims |

### Neutrals (Text & Borders)

| Role | HEX | Usage | WCAG |
|------|-----|--------|------|
| **Text Primary** | `#1C1917` | Body, headings | 12.6:1 on #FAFAF9 |
| **Text Secondary** | `#57534E` | Supporting text | 6.2:1 |
| **Text Muted** | `#78716C` | Captions, hints | 4.6:1 |
| **Border** | `#E7E5E4` | Dividers, inputs | – |

### Semantic

| Role | HEX | Usage |
|------|-----|--------|
| **Success** | `#059669` | Confirmations, success states |
| **Success Light** | `#D1FAE5` | Success backgrounds |
| **Error** | `#DC2626` | Errors, destructive actions |
| **Error Light** | `#FEE2E2` | Error backgrounds |
| **Warning** | `#D97706` | Warnings |

All semantic text-on-background pairings meet **WCAG AA** (4.5:1+ for normal text, 3:1+ for large).

---

## 2. Typography System

### Font Pairing

- **Headings:** System UI stack with optional **Plus Jakarta Sans** (or similar) for a modern, friendly sans.
- **Body:** System stack for performance and native feel.

```css
--font-family-heading: 'Plus Jakarta Sans', -apple-system, BlinkMacSystemFont, 'Segoe UI', sans-serif;
--font-family-body: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif;
```

### Scale (Mobile-First)

| Token | Size | Line height | Use |
|-------|------|-------------|-----|
| `xs` | 12px | 1.35 | Captions, labels |
| `sm` | 14px | 1.45 | Secondary text, table cells |
| `base` | 16px | 1.5 | Body |
| `lg` | 18px | 1.4 | Lead, card titles |
| `xl` | 20px | 1.3 | Section titles |
| `2xl` | 24px | 1.25 | Page section |
| `3xl` | 30px | 1.2 | Page title |
| `4xl` | 36px | 1.15 | Hero |

### Weights

- **Regular (400):** Body.
- **Medium (500):** Labels, emphasis.
- **Semibold (600):** Headings, buttons.
- **Bold (700):** Hero, primary CTAs.

---

## 3. Spacing System

8px base unit:

| Token | Value | Use |
|-------|--------|-----|
| 1 | 4px | Icon gaps, tight spacing |
| 2 | 8px | Inline spacing |
| 3 | 12px | Compact padding |
| 4 | 16px | Default padding |
| 5 | 20px | Form groups |
| 6 | 24px | Card padding, sections |
| 8 | 32px | Section spacing |
| 10 | 40px | Large sections |
| 12 | 48px | Hero / screen spacing |
| 16 | 64px | Major layout blocks |

---

## 4. UI Component Styling Guide

### Buttons

- **Primary (CTA):** Accent background (`#B45309`), white text, 12px radius, min height 48px, soft shadow.
- **Secondary:** Outline or surface fill; Primary or Secondary border.
- **Ghost:** Transparent, for low-emphasis actions.
- **Rounded:** `border-radius: 12px` (or 9999px for pills).

### Cards

- **Surface:** White, 16px radius, soft shadow (`0 1px 3px rgba(0,0,0,0.08)`).
- **Hover:** Slight lift and stronger shadow for clickable cards.
- **Optional:** Subtle border `1px solid #E7E5E4` for definition.

### Inputs

- **Height:** 48px min (touch-friendly).
- **Border:** 1px `#E7E5E4`, 8px radius.
- **Focus:** 2px Primary ring, no harsh outline.

### Depth & Shadows

- **xs:** `0 1px 2px rgba(0,0,0,0.05)`
- **sm:** `0 2px 4px rgba(0,0,0,0.06), 0 1px 2px rgba(0,0,0,0.04)`
- **md:** `0 4px 12px rgba(0,0,0,0.08), 0 2px 4px rgba(0,0,0,0.04)`
- **lg:** `0 12px 24px rgba(0,0,0,0.08), 0 4px 8px rgba(0,0,0,0.04)`

### Glassmorphism (Optional)

- **Background:** `rgba(255,255,255,0.85)` with `backdrop-filter: blur(12px)`.
- **Use:** Nav bar, floating panels, modals.
- **Border:** `1px solid rgba(255,255,255,0.5)`.

### Rounded Corners

- **Small:** 6px (badges, tags).
- **Medium:** 10px (buttons, inputs).
- **Large:** 16px (cards, modals).
- **Full:** 9999px (pills, avatars).

---

## 5. Key Screens – Design Direction

### Home Screen

- **Hero:** Short welcome line + primary CTA (e.g. “Explore rooms” or “New booking”).
- **Stats:** 2–3 metric cards (e.g. total bookings, quick actions) with clear hierarchy and icon + number + label.
- **Recent activity:** Table or list of recent bookings with clear typography and one primary action (e.g. “View all”).
- **Empty state:** Illustration or icon, one line of copy, single CTA.

### Room Listing Page

- **Toolbar:** Search + filters (chips or dropdown) aligned with new spacing/radius.
- **Cards:** Image (or placeholder), title, location, price, rating/badge, single primary CTA (“Book” / “View”).
- **Layout:** Single column on mobile; 2 columns on tablet+.
- **Trust:** Small ratings/badges on each card.

### Room Details Page

- **Media:** Hero image or gallery; optional soft overlay for text.
- **Block structure:** Title → key info (room type, capacity) → short description → amenities (icons + text) → price + sticky CTA.
- **Sticky CTA:** Bar at bottom with price + “Book now” (accent button).

### Booking Confirmation

- **Success state:** Checkmark icon, “Booking confirmed” title, short summary (dates, room, guest).
- **Secondary:** “View booking” or “Back to home” as secondary actions.
- **Tone:** Calm (primary/success green), minimal clutter.

---

## 6. Design Decisions – Brief Reasoning

| Decision | Reason |
|----------|--------|
| **Teal primary** | Trust and calm; fits travel/hospitality; stands out from generic blue. |
| **Amber accent for CTAs** | Warmth and urgency; increases visibility and click-through. |
| **Warm off-white background** | Softer than pure white; feels premium and easy on the eye. |
| **Soft shadows** | Depth without heaviness; modern and clean. |
| **16px card radius** | Friendly, approachable; aligns with current trends. |
| **48px min touch targets** | Accessibility and mobile-first; fewer mis-taps. |
| **System font + optional Plus Jakarta Sans** | Performance and reliability with option for a more distinctive headline look. |

---

## 7. Luxury & Conversion Suggestions

1. **Imagery:** Use high-quality room and property photos; avoid generic stock where possible.
2. **Social proof:** Ratings, review count, and “X booked recently” on listing and details.
3. **Scarcity (ethical):** “Only X rooms left” only when true; builds urgency.
4. **One primary CTA per screen:** e.g. one “Book now” or “Reserve” per context.
5. **Price clarity:** Show total or “from $X” clearly; avoid hidden fees in UI copy.
6. **Microcopy:** Use “Reserve” or “Confirm booking” for final step; “Explore rooms” for listing.
7. **Loading & success:** Skeleton loaders for lists; clear success state (e.g. confirmation screen or toast) after booking.
8. **Consistency:** Same accent color for all primary CTAs; same card style across listing and details.

---

## 8. Accessibility (WCAG)

- **Contrast:** Text-primary and text-secondary on background meet AA (4.5:1). Large text and UI components meet 3:1 where required.
- **Focus:** Visible focus ring (e.g. 2px Primary) on all interactive elements.
- **Touch:** Minimum 44×44px tap targets; spacing between targets.
- **Labels:** All inputs have visible labels; errors are associated and announced.

---

## 9. UI Component Styling Guide (Quick Reference)

| Component | Classes | Notes |
|-----------|---------|--------|
| **Primary CTA** | `btn btn-accent` | Book Now, Reserve, Create Booking |
| **Secondary action** | `btn btn-primary` or `btn btn-outline-primary` | Edit, View all |
| **Card (default)** | `card` | 16px radius, soft shadow |
| **Card (interactive)** | `card card-elevated` | Hover: lift + stronger shadow |
| **Luxury badge** | `badge badge-gold` | Room type, premium labels |
| **Nav bar** | `navbar navbar-glass` | Glassmorphism (blur + transparency) |
| **Form control** | `form-control` | 12px radius, 48px min height |
| **Page title** | Use `color: var(--color-secondary)` | Headings |
| **Success price** | `color: var(--color-success)` | Totals, confirmed amounts |

---

## 10. Booking Confirmation Screen

After **Create Booking**, the user is redirected to **Confirmation (id)**:

- Large success checkmark (green circle).
- “Booking Confirmed” title and short thank-you copy.
- Summary: Booking #, Guest, Room, City, Total (with success color for total).
- Primary CTA: “View / Edit Booking” (accent).
- Secondary: “All Bookings” (outline).

This screen reinforces trust and gives a clear next step, supporting perceived luxury and conversion.

---

This design system is implemented in `wwwroot/css/design-system.css` and `wwwroot/css/site.css`, and applied across the app’s key screens for a consistent, premium, and conversion-focused experience.

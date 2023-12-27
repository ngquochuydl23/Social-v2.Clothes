/*! For license information please see 105.db09d5d7.chunk.js.LICENSE.txt */
(self.webpackChunkciseco_client=self.webpackChunkciseco_client||[]).push([[105],{9606:function(t,e,n){var r=n(9987).default,i=["title","titleId"],o=n(2791);var s=o.forwardRef((function(t,e){var n=t.title,s=t.titleId,a=r(t,i);return o.createElement("svg",Object.assign({xmlns:"http://www.w3.org/2000/svg",viewBox:"0 0 24 24",fill:"currentColor","aria-hidden":"true",ref:e,"aria-labelledby":s},a),n?o.createElement("title",{id:s},n):null,o.createElement("path",{fillRule:"evenodd",d:"M10.5 3.75a6.75 6.75 0 100 13.5 6.75 6.75 0 000-13.5zM2.25 10.5a8.25 8.25 0 1114.59 5.28l4.69 4.69a.75.75 0 11-1.06 1.06l-4.69-4.69A8.25 8.25 0 012.25 10.5z",clipRule:"evenodd"}))}));t.exports=s},3290:function(){},5301:function(t,e,n){"use strict";function r(t){return r="function"===typeof Symbol&&"symbol"===typeof Symbol.iterator?function(t){return typeof t}:function(t){return t&&"function"===typeof Symbol&&t.constructor===Symbol&&t!==Symbol.prototype?"symbol":typeof t},r(t)}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function o(t,e){for(var n=0;n<e.length;n++){var r=e[n];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(t,r.key,r)}}function s(t,e,n){return e&&o(t.prototype,e),n&&o(t,n),t}function a(t){return a=Object.setPrototypeOf?Object.getPrototypeOf:function(t){return t.__proto__||Object.getPrototypeOf(t)},a(t)}function u(t,e){return u=Object.setPrototypeOf||function(t,e){return t.__proto__=e,t},u(t,e)}function c(t,e){if(e&&("object"===typeof e||"function"===typeof e))return e;if(void 0!==e)throw new TypeError("Derived constructors may only return object or undefined");return function(t){if(void 0===t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return t}(t)}function l(t){var e=function(){if("undefined"===typeof Reflect||!Reflect.construct)return!1;if(Reflect.construct.sham)return!1;if("function"===typeof Proxy)return!0;try{return Boolean.prototype.valueOf.call(Reflect.construct(Boolean,[],(function(){}))),!0}catch(t){return!1}}();return function(){var n,r=a(t);if(e){var i=a(this).constructor;n=Reflect.construct(r,arguments,i)}else n=r.apply(this,arguments);return c(this,n)}}function f(){return f="undefined"!==typeof Reflect&&Reflect.get?Reflect.get:function(t,e,n){var r=function(t,e){for(;!Object.prototype.hasOwnProperty.call(t,e)&&null!==(t=a(t)););return t}(t,e);if(r){var i=Object.getOwnPropertyDescriptor(r,e);return i.get?i.get.call(arguments.length<3?t:n):i.value}},f.apply(this,arguments)}n.d(e,{Z:function(){return $}});var d={type:"slider",startAt:0,perView:1,focusAt:0,gap:10,autoplay:!1,hoverpause:!0,keyboard:!0,bound:!1,swipeThreshold:80,dragThreshold:120,perSwipe:"",touchRatio:.5,touchAngle:45,animationDuration:400,rewind:!0,rewindDuration:800,animationTimingFunc:"cubic-bezier(.165, .840, .440, 1)",waitForTransition:!0,throttle:10,direction:"ltr",peek:0,cloningRatio:1,breakpoints:{},classes:{swipeable:"glide--swipeable",dragging:"glide--dragging",direction:{ltr:"glide--ltr",rtl:"glide--rtl"},type:{slider:"glide--slider",carousel:"glide--carousel"},slide:{clone:"glide__slide--clone",active:"glide__slide--active"},arrow:{disabled:"glide__arrow--disabled"},nav:{active:"glide__bullet--active"}}};function v(t){console.error("[Glide warn]: ".concat(t))}function h(t){return parseInt(t)}function p(t){return"string"===typeof t}function m(t){var e=r(t);return"function"===e||"object"===e&&!!t}function g(t){return"function"===typeof t}function b(t){return"undefined"===typeof t}function y(t){return t.constructor===Array}function w(t,e,n){Object.defineProperty(t,e,n)}function x(t,e){var n=Object.assign({},t,e);return e.hasOwnProperty("classes")&&(n.classes=Object.assign({},t.classes,e.classes),e.classes.hasOwnProperty("direction")&&(n.classes.direction=Object.assign({},t.classes.direction,e.classes.direction)),e.classes.hasOwnProperty("type")&&(n.classes.type=Object.assign({},t.classes.type,e.classes.type)),e.classes.hasOwnProperty("slide")&&(n.classes.slide=Object.assign({},t.classes.slide,e.classes.slide)),e.classes.hasOwnProperty("arrow")&&(n.classes.arrow=Object.assign({},t.classes.arrow,e.classes.arrow)),e.classes.hasOwnProperty("nav")&&(n.classes.nav=Object.assign({},t.classes.nav,e.classes.nav))),e.hasOwnProperty("breakpoints")&&(n.breakpoints=Object.assign({},t.breakpoints,e.breakpoints)),n}var T=function(){function t(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{};i(this,t),this.events=e,this.hop=e.hasOwnProperty}return s(t,[{key:"on",value:function(t,e){if(!y(t)){this.hop.call(this.events,t)||(this.events[t]=[]);var n=this.events[t].push(e)-1;return{remove:function(){delete this.events[t][n]}}}for(var r=0;r<t.length;r++)this.on(t[r],e)}},{key:"emit",value:function(t,e){if(y(t))for(var n=0;n<t.length;n++)this.emit(t[n],e);else this.hop.call(this.events,t)&&this.events[t].forEach((function(t){t(e||{})}))}}]),t}(),_=function(){function t(e){var n=arguments.length>1&&void 0!==arguments[1]?arguments[1]:{};i(this,t),this._c={},this._t=[],this._e=new T,this.disabled=!1,this.selector=e,this.settings=x(d,n),this.index=this.settings.startAt}return s(t,[{key:"mount",value:function(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{};return this._e.emit("mount.before"),m(t)?this._c=function(t,e,n){var r={};for(var i in e)g(e[i])?r[i]=e[i](t,r,n):v("Extension must be a function");for(var o in r)g(r[o].mount)&&r[o].mount();return r}(this,t,this._e):v("You need to provide a object on `mount()`"),this._e.emit("mount.after"),this}},{key:"mutate",value:function(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:[];return y(t)?this._t=t:v("You need to provide a array on `mutate()`"),this}},{key:"update",value:function(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{};return this.settings=x(this.settings,t),t.hasOwnProperty("startAt")&&(this.index=t.startAt),this._e.emit("update"),this}},{key:"go",value:function(t){return this._c.Run.make(t),this}},{key:"move",value:function(t){return this._c.Transition.disable(),this._c.Move.make(t),this}},{key:"destroy",value:function(){return this._e.emit("destroy"),this}},{key:"play",value:function(){var t=arguments.length>0&&void 0!==arguments[0]&&arguments[0];return t&&(this.settings.autoplay=t),this._e.emit("play"),this}},{key:"pause",value:function(){return this._e.emit("pause"),this}},{key:"disable",value:function(){return this.disabled=!0,this}},{key:"enable",value:function(){return this.disabled=!1,this}},{key:"on",value:function(t,e){return this._e.on(t,e),this}},{key:"isType",value:function(t){return this.settings.type===t}},{key:"settings",get:function(){return this._o},set:function(t){m(t)?this._o=t:v("Options must be an `object` instance.")}},{key:"index",get:function(){return this._i},set:function(t){this._i=h(t)}},{key:"type",get:function(){return this.settings.type}},{key:"disabled",get:function(){return this._d},set:function(t){this._d=!!t}}]),t}();function k(){return(new Date).getTime()}function S(t,e,n){var r,i,o,s,a=0;n||(n={});var u=function(){a=!1===n.leading?0:k(),r=null,s=t.apply(i,o),r||(i=o=null)},c=function(){var c=k();a||!1!==n.leading||(a=c);var l=e-(c-a);return i=this,o=arguments,l<=0||l>e?(r&&(clearTimeout(r),r=null),a=c,s=t.apply(i,o),r||(i=o=null)):r||!1===n.trailing||(r=setTimeout(u,l)),s};return c.cancel=function(){clearTimeout(r),a=0,r=i=o=null},c}var O={ltr:["marginLeft","marginRight"],rtl:["marginRight","marginLeft"]};function E(t){if(t&&t.parentNode){for(var e=t.parentNode.firstChild,n=[];e;e=e.nextSibling)1===e.nodeType&&e!==t&&n.push(e);return n}return[]}function A(t){return!!(t&&t instanceof window.HTMLElement)}function P(t){return Array.prototype.slice.call(t)}var R='[data-glide-el="track"]';var H=function(){function t(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{};i(this,t),this.listeners=e}return s(t,[{key:"on",value:function(t,e,n){var r=arguments.length>3&&void 0!==arguments[3]&&arguments[3];p(t)&&(t=[t]);for(var i=0;i<t.length;i++)this.listeners[t[i]]=n,e.addEventListener(t[i],this.listeners[t[i]],r)}},{key:"off",value:function(t,e){var n=arguments.length>2&&void 0!==arguments[2]&&arguments[2];p(t)&&(t=[t]);for(var r=0;r<t.length;r++)e.removeEventListener(t[r],this.listeners[t[r]],n)}},{key:"destroy",value:function(){delete this.listeners}}]),t}();var I=["ltr","rtl"],C={">":"<","<":">","=":"="};function j(t,e){return{modify:function(t){return e.Direction.is("rtl")?-t:t}}}function z(t,e){return{modify:function(t){var n=Math.floor(t/e.Sizes.slideWidth);return t+e.Gaps.value*n}}}function M(t,e){return{modify:function(t){return t+e.Clones.grow/2}}}function Z(t,e){return{modify:function(n){if(t.settings.focusAt>=0){var r=e.Peek.value;return m(r)?n-r.before:n-r}return n}}}function L(t,e){return{modify:function(n){var r=e.Gaps.value,i=e.Sizes.width,o=t.settings.focusAt,s=e.Sizes.slideWidth;return"center"===o?n-(i/2-s/2):n-s*o-r*o}}}var D=!1;try{var B=Object.defineProperty({},"passive",{get:function(){D=!0}});window.addEventListener("testPassive",null,B),window.removeEventListener("testPassive",null,B)}catch(J){}var F=D,W=["touchstart","mousedown"],V=["touchmove","mousemove"],q=["touchend","touchcancel","mouseup","mouseleave"],N=["mousedown","mousemove","mouseup","mouseleave"];var G='[data-glide-el^="controls"]',Y="".concat(G,' [data-glide-dir*="<"]'),U="".concat(G,' [data-glide-dir*=">"]');function X(t){return m(t)?(e=t,Object.keys(e).sort().reduce((function(t,n){return t[n]=e[n],t[n],t}),{})):(v("Breakpoints option must be an object"),{});var e}var K={Html:function(t,e,n){var r={mount:function(){this.root=t.selector,this.track=this.root.querySelector(R),this.collectSlides()},collectSlides:function(){this.slides=P(this.wrapper.children).filter((function(e){return!e.classList.contains(t.settings.classes.slide.clone)}))}};return w(r,"root",{get:function(){return r._r},set:function(t){p(t)&&(t=document.querySelector(t)),A(t)?r._r=t:v("Root element must be a existing Html node")}}),w(r,"track",{get:function(){return r._t},set:function(t){A(t)?r._t=t:v("Could not find track element. Please use ".concat(R," attribute."))}}),w(r,"wrapper",{get:function(){return r.track.children[0]}}),n.on("update",(function(){r.collectSlides()})),r},Translate:function(t,e,n){var r={set:function(n){var r=function(t,e,n){var r=[z,M,Z,L].concat(t._t,[j]);return{mutate:function(i){for(var o=0;o<r.length;o++){var s=r[o];g(s)&&g(s().modify)?i=s(t,e,n).modify(i):v("Transformer should be a function that returns an object with `modify()` method")}return i}}}(t,e).mutate(n),i="translate3d(".concat(-1*r,"px, 0px, 0px)");e.Html.wrapper.style.mozTransform=i,e.Html.wrapper.style.webkitTransform=i,e.Html.wrapper.style.transform=i},remove:function(){e.Html.wrapper.style.transform=""},getStartIndex:function(){var n=e.Sizes.length,r=t.index,i=t.settings.perView;return e.Run.isOffset(">")||e.Run.isOffset("|>")?n+(r-i):(r+i)%n},getTravelDistance:function(){var n=e.Sizes.slideWidth*t.settings.perView;return e.Run.isOffset(">")||e.Run.isOffset("|>")?-1*n:n}};return n.on("move",(function(i){if(!t.isType("carousel")||!e.Run.isOffset())return r.set(i.movement);e.Transition.after((function(){n.emit("translate.jump"),r.set(e.Sizes.slideWidth*t.index)}));var o=e.Sizes.slideWidth*e.Translate.getStartIndex();return r.set(o-e.Translate.getTravelDistance())})),n.on("destroy",(function(){r.remove()})),r},Transition:function(t,e,n){var r=!1,i={compose:function(e){var n=t.settings;return r?"".concat(e," 0ms ").concat(n.animationTimingFunc):"".concat(e," ").concat(this.duration,"ms ").concat(n.animationTimingFunc)},set:function(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"transform";e.Html.wrapper.style.transition=this.compose(t)},remove:function(){e.Html.wrapper.style.transition=""},after:function(t){setTimeout((function(){t()}),this.duration)},enable:function(){r=!1,this.set()},disable:function(){r=!0,this.set()}};return w(i,"duration",{get:function(){var n=t.settings;return t.isType("slider")&&e.Run.offset?n.rewindDuration:n.animationDuration}}),n.on("move",(function(){i.set()})),n.on(["build.before","resize","translate.jump"],(function(){i.disable()})),n.on("run",(function(){i.enable()})),n.on("destroy",(function(){i.remove()})),i},Direction:function(t,e,n){var r={mount:function(){this.value=t.settings.direction},resolve:function(t){var e=t.slice(0,1);return this.is("rtl")?t.split(e).join(C[e]):t},is:function(t){return this.value===t},addClass:function(){e.Html.root.classList.add(t.settings.classes.direction[this.value])},removeClass:function(){e.Html.root.classList.remove(t.settings.classes.direction[this.value])}};return w(r,"value",{get:function(){return r._v},set:function(t){I.indexOf(t)>-1?r._v=t:v("Direction value must be `ltr` or `rtl`")}}),n.on(["destroy","update"],(function(){r.removeClass()})),n.on("update",(function(){r.mount()})),n.on(["build.before","update"],(function(){r.addClass()})),r},Peek:function(t,e,n){var r={mount:function(){this.value=t.settings.peek}};return w(r,"value",{get:function(){return r._v},set:function(t){m(t)?(t.before=h(t.before),t.after=h(t.after)):t=h(t),r._v=t}}),w(r,"reductor",{get:function(){var e=r.value,n=t.settings.perView;return m(e)?e.before/n+e.after/n:2*e/n}}),n.on(["resize","update"],(function(){r.mount()})),r},Sizes:function(t,e,n){var r={setupSlides:function(){for(var t="".concat(this.slideWidth,"px"),n=e.Html.slides,r=0;r<n.length;r++)n[r].style.width=t},setupWrapper:function(){e.Html.wrapper.style.width="".concat(this.wrapperSize,"px")},remove:function(){for(var t=e.Html.slides,n=0;n<t.length;n++)t[n].style.width="";e.Html.wrapper.style.width=""}};return w(r,"length",{get:function(){return e.Html.slides.length}}),w(r,"width",{get:function(){return e.Html.track.offsetWidth}}),w(r,"wrapperSize",{get:function(){return r.slideWidth*r.length+e.Gaps.grow+e.Clones.grow}}),w(r,"slideWidth",{get:function(){return r.width/t.settings.perView-e.Peek.reductor-e.Gaps.reductor}}),n.on(["build.before","resize","update"],(function(){r.setupSlides(),r.setupWrapper()})),n.on("destroy",(function(){r.remove()})),r},Gaps:function(t,e,n){var r={apply:function(t){for(var n=0,r=t.length;n<r;n++){var i=t[n].style,o=e.Direction.value;i[O[o][0]]=0!==n?"".concat(this.value/2,"px"):"",n!==t.length-1?i[O[o][1]]="".concat(this.value/2,"px"):i[O[o][1]]=""}},remove:function(t){for(var e=0,n=t.length;e<n;e++){var r=t[e].style;r.marginLeft="",r.marginRight=""}}};return w(r,"value",{get:function(){return h(t.settings.gap)}}),w(r,"grow",{get:function(){return r.value*e.Sizes.length}}),w(r,"reductor",{get:function(){var e=t.settings.perView;return r.value*(e-1)/e}}),n.on(["build.after","update"],S((function(){r.apply(e.Html.wrapper.children)}),30)),n.on("destroy",(function(){r.remove(e.Html.wrapper.children)})),r},Move:function(t,e,n){var r={mount:function(){this._o=0},make:function(){var t=this,r=arguments.length>0&&void 0!==arguments[0]?arguments[0]:0;this.offset=r,n.emit("move",{movement:this.value}),e.Transition.after((function(){n.emit("move.after",{movement:t.value})}))}};return w(r,"offset",{get:function(){return r._o},set:function(t){r._o=b(t)?0:h(t)}}),w(r,"translate",{get:function(){return e.Sizes.slideWidth*t.index}}),w(r,"value",{get:function(){var t=this.offset,n=this.translate;return e.Direction.is("rtl")?n+t:n-t}}),n.on(["build.before","run"],(function(){r.make()})),r},Clones:function(t,e,n){var r={mount:function(){this.items=[],t.isType("carousel")&&(this.items=this.collect())},collect:function(){var n=arguments.length>0&&void 0!==arguments[0]?arguments[0]:[],r=e.Html.slides,i=t.settings,o=i.perView,s=i.classes,a=i.cloningRatio;if(0!==r.length)for(var u=o+ +!!t.settings.peek+Math.round(o/2),c=r.slice(0,u).reverse(),l=r.slice(-1*u),f=0;f<Math.max(a,Math.floor(o/r.length));f++){for(var d=0;d<c.length;d++){var v=c[d].cloneNode(!0);v.classList.add(s.slide.clone),n.push(v)}for(var h=0;h<l.length;h++){var p=l[h].cloneNode(!0);p.classList.add(s.slide.clone),n.unshift(p)}}return n},append:function(){for(var t=this.items,n=e.Html,r=n.wrapper,i=n.slides,o=Math.floor(t.length/2),s=t.slice(0,o).reverse(),a=t.slice(-1*o).reverse(),u="".concat(e.Sizes.slideWidth,"px"),c=0;c<a.length;c++)r.appendChild(a[c]);for(var l=0;l<s.length;l++)r.insertBefore(s[l],i[0]);for(var f=0;f<t.length;f++)t[f].style.width=u},remove:function(){for(var t=this.items,n=0;n<t.length;n++)e.Html.wrapper.removeChild(t[n])}};return w(r,"grow",{get:function(){return(e.Sizes.slideWidth+e.Gaps.value)*r.items.length}}),n.on("update",(function(){r.remove(),r.mount(),r.append()})),n.on("build.before",(function(){t.isType("carousel")&&r.append()})),n.on("destroy",(function(){r.remove()})),r},Resize:function(t,e,n){var r=new H,i={mount:function(){this.bind()},bind:function(){r.on("resize",window,S((function(){n.emit("resize")}),t.settings.throttle))},unbind:function(){r.off("resize",window)}};return n.on("destroy",(function(){i.unbind(),r.destroy()})),i},Build:function(t,e,n){var r={mount:function(){n.emit("build.before"),this.typeClass(),this.activeClass(),n.emit("build.after")},typeClass:function(){e.Html.root.classList.add(t.settings.classes.type[t.settings.type])},activeClass:function(){var n=t.settings.classes,r=e.Html.slides[t.index];r&&(r.classList.add(n.slide.active),E(r).forEach((function(t){t.classList.remove(n.slide.active)})))},removeClasses:function(){var n=t.settings.classes,r=n.type,i=n.slide;e.Html.root.classList.remove(r[t.settings.type]),e.Html.slides.forEach((function(t){t.classList.remove(i.active)}))}};return n.on(["destroy","update"],(function(){r.removeClasses()})),n.on(["resize","update"],(function(){r.mount()})),n.on("move.after",(function(){r.activeClass()})),r},Run:function(t,e,n){var r={mount:function(){this._o=!1},make:function(r){var i=this;t.disabled||(!t.settings.waitForTransition||t.disable(),this.move=r,n.emit("run.before",this.move),this.calculate(),n.emit("run",this.move),e.Transition.after((function(){i.isStart()&&n.emit("run.start",i.move),i.isEnd()&&n.emit("run.end",i.move),i.isOffset()&&(i._o=!1,n.emit("run.offset",i.move)),n.emit("run.after",i.move),t.enable()})))},calculate:function(){var e=this.move,n=this.length,i=e.steps,o=e.direction,s=1;if("="===o)return t.settings.bound&&h(i)>n?void(t.index=n):void(t.index=i);if(">"!==o||">"!==i)if("<"!==o||"<"!==i){if("|"===o&&(s=t.settings.perView||1),">"===o||"|"===o&&">"===i){var a=function(e){var n=t.index;if(t.isType("carousel"))return n+e;return n+(e-n%e)}(s);return a>n&&(this._o=!0),void(t.index=function(e,n){var i=r.length;if(e<=i)return e;if(t.isType("carousel"))return e-(i+1);if(t.settings.rewind)return r.isBound()&&!r.isEnd()?i:0;if(r.isBound())return i;return Math.floor(i/n)*n}(a,s))}if("<"===o||"|"===o&&"<"===i){var u=function(e){var n=t.index;if(t.isType("carousel"))return n-e;var r=Math.ceil(n/e);return(r-1)*e}(s);return u<0&&(this._o=!0),void(t.index=function(e,n){var i=r.length;if(e>=0)return e;if(t.isType("carousel"))return e+(i+1);if(t.settings.rewind)return r.isBound()&&r.isStart()?i:Math.floor(i/n)*n;return 0}(u,s))}v("Invalid direction pattern [".concat(o).concat(i,"] has been used"))}else t.index=0;else t.index=n},isStart:function(){return t.index<=0},isEnd:function(){return t.index>=this.length},isOffset:function(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:void 0;return t?!!this._o&&("|>"===t?"|"===this.move.direction&&">"===this.move.steps:"|<"===t?"|"===this.move.direction&&"<"===this.move.steps:this.move.direction===t):this._o},isBound:function(){return t.isType("slider")&&"center"!==t.settings.focusAt&&t.settings.bound}};return w(r,"move",{get:function(){return this._m},set:function(t){var e=t.substr(1);this._m={direction:t.substr(0,1),steps:e?h(e)?h(e):e:0}}}),w(r,"length",{get:function(){var n=t.settings,r=e.Html.slides.length;return this.isBound()?r-1-(h(n.perView)-1)+h(n.focusAt):r-1}}),w(r,"offset",{get:function(){return this._o}}),r},Swipe:function(t,e,n){var r=new H,i=0,o=0,s=0,a=!1,u=!!F&&{passive:!0},c={mount:function(){this.bindSwipeStart()},start:function(e){if(!a&&!t.disabled){this.disable();var r=this.touches(e);i=null,o=h(r.pageX),s=h(r.pageY),this.bindSwipeMove(),this.bindSwipeEnd(),n.emit("swipe.start")}},move:function(r){if(!t.disabled){var a=t.settings,u=a.touchAngle,c=a.touchRatio,l=a.classes,f=this.touches(r),d=h(f.pageX)-o,v=h(f.pageY)-s,p=Math.abs(d<<2),m=Math.abs(v<<2),g=Math.sqrt(p+m),b=Math.sqrt(m);if(!(180*(i=Math.asin(b/g))/Math.PI<u))return!1;r.stopPropagation(),e.Move.make(d*parseFloat(c)),e.Html.root.classList.add(l.dragging),n.emit("swipe.move")}},end:function(r){if(!t.disabled){var s=t.settings,a=s.perSwipe,u=s.touchAngle,c=s.classes,l=this.touches(r),f=this.threshold(r),d=l.pageX-o,v=180*i/Math.PI;this.enable(),d>f&&v<u?e.Run.make(e.Direction.resolve("".concat(a,"<"))):d<-f&&v<u?e.Run.make(e.Direction.resolve("".concat(a,">"))):e.Move.make(),e.Html.root.classList.remove(c.dragging),this.unbindSwipeMove(),this.unbindSwipeEnd(),n.emit("swipe.end")}},bindSwipeStart:function(){var n=this,i=t.settings,o=i.swipeThreshold,s=i.dragThreshold;o&&r.on(W[0],e.Html.wrapper,(function(t){n.start(t)}),u),s&&r.on(W[1],e.Html.wrapper,(function(t){n.start(t)}),u)},unbindSwipeStart:function(){r.off(W[0],e.Html.wrapper,u),r.off(W[1],e.Html.wrapper,u)},bindSwipeMove:function(){var n=this;r.on(V,e.Html.wrapper,S((function(t){n.move(t)}),t.settings.throttle),u)},unbindSwipeMove:function(){r.off(V,e.Html.wrapper,u)},bindSwipeEnd:function(){var t=this;r.on(q,e.Html.wrapper,(function(e){t.end(e)}))},unbindSwipeEnd:function(){r.off(q,e.Html.wrapper)},touches:function(t){return N.indexOf(t.type)>-1?t:t.touches[0]||t.changedTouches[0]},threshold:function(e){var n=t.settings;return N.indexOf(e.type)>-1?n.dragThreshold:n.swipeThreshold},enable:function(){return a=!1,e.Transition.enable(),this},disable:function(){return a=!0,e.Transition.disable(),this}};return n.on("build.after",(function(){e.Html.root.classList.add(t.settings.classes.swipeable)})),n.on("destroy",(function(){c.unbindSwipeStart(),c.unbindSwipeMove(),c.unbindSwipeEnd(),r.destroy()})),c},Images:function(t,e,n){var r=new H,i={mount:function(){this.bind()},bind:function(){r.on("dragstart",e.Html.wrapper,this.dragstart)},unbind:function(){r.off("dragstart",e.Html.wrapper)},dragstart:function(t){t.preventDefault()}};return n.on("destroy",(function(){i.unbind(),r.destroy()})),i},Anchors:function(t,e,n){var r=new H,i=!1,o=!1,s={mount:function(){this._a=e.Html.wrapper.querySelectorAll("a"),this.bind()},bind:function(){r.on("click",e.Html.wrapper,this.click)},unbind:function(){r.off("click",e.Html.wrapper)},click:function(t){o&&(t.stopPropagation(),t.preventDefault())},detach:function(){if(o=!0,!i){for(var t=0;t<this.items.length;t++)this.items[t].draggable=!1;i=!0}return this},attach:function(){if(o=!1,i){for(var t=0;t<this.items.length;t++)this.items[t].draggable=!0;i=!1}return this}};return w(s,"items",{get:function(){return s._a}}),n.on("swipe.move",(function(){s.detach()})),n.on("swipe.end",(function(){e.Transition.after((function(){s.attach()}))})),n.on("destroy",(function(){s.attach(),s.unbind(),r.destroy()})),s},Controls:function(t,e,n){var r=new H,i=!!F&&{passive:!0},o={mount:function(){this._n=e.Html.root.querySelectorAll('[data-glide-el="controls[nav]"]'),this._c=e.Html.root.querySelectorAll(G),this._arrowControls={previous:e.Html.root.querySelectorAll(Y),next:e.Html.root.querySelectorAll(U)},this.addBindings()},setActive:function(){for(var t=0;t<this._n.length;t++)this.addClass(this._n[t].children)},removeActive:function(){for(var t=0;t<this._n.length;t++)this.removeClass(this._n[t].children)},addClass:function(e){var n=t.settings,r=e[t.index];r&&r&&(r.classList.add(n.classes.nav.active),E(r).forEach((function(t){t.classList.remove(n.classes.nav.active)})))},removeClass:function(e){var n=e[t.index];n&&n.classList.remove(t.settings.classes.nav.active)},setArrowState:function(){if(!t.settings.rewind){var n=o._arrowControls.next,r=o._arrowControls.previous;this.resetArrowState(n,r),0===t.index&&this.disableArrow(r),t.index===e.Run.length&&this.disableArrow(n)}},resetArrowState:function(){for(var e=t.settings,n=arguments.length,r=new Array(n),i=0;i<n;i++)r[i]=arguments[i];r.forEach((function(t){P(t).forEach((function(t){t.classList.remove(e.classes.arrow.disabled)}))}))},disableArrow:function(){for(var e=t.settings,n=arguments.length,r=new Array(n),i=0;i<n;i++)r[i]=arguments[i];r.forEach((function(t){P(t).forEach((function(t){t.classList.add(e.classes.arrow.disabled)}))}))},addBindings:function(){for(var t=0;t<this._c.length;t++)this.bind(this._c[t].children)},removeBindings:function(){for(var t=0;t<this._c.length;t++)this.unbind(this._c[t].children)},bind:function(t){for(var e=0;e<t.length;e++)r.on("click",t[e],this.click),r.on("touchstart",t[e],this.click,i)},unbind:function(t){for(var e=0;e<t.length;e++)r.off(["click","touchstart"],t[e])},click:function(t){F||"touchstart"!==t.type||t.preventDefault();var n=t.currentTarget.getAttribute("data-glide-dir");e.Run.make(e.Direction.resolve(n))}};return w(o,"items",{get:function(){return o._c}}),n.on(["mount.after","move.after"],(function(){o.setActive()})),n.on(["mount.after","run"],(function(){o.setArrowState()})),n.on("destroy",(function(){o.removeBindings(),o.removeActive(),r.destroy()})),o},Keyboard:function(t,e,n){var r=new H,i={mount:function(){t.settings.keyboard&&this.bind()},bind:function(){r.on("keyup",document,this.press)},unbind:function(){r.off("keyup",document)},press:function(n){var r=t.settings.perSwipe;"ArrowRight"===n.code&&e.Run.make(e.Direction.resolve("".concat(r,">"))),"ArrowLeft"===n.code&&e.Run.make(e.Direction.resolve("".concat(r,"<")))}};return n.on(["destroy","update"],(function(){i.unbind()})),n.on("update",(function(){i.mount()})),n.on("destroy",(function(){r.destroy()})),i},Autoplay:function(t,e,n){var r=new H,i={mount:function(){this.enable(),this.start(),t.settings.hoverpause&&this.bind()},enable:function(){this._e=!0},disable:function(){this._e=!1},start:function(){var r=this;this._e&&(this.enable(),t.settings.autoplay&&b(this._i)&&(this._i=setInterval((function(){r.stop(),e.Run.make(">"),r.start(),n.emit("autoplay")}),this.time)))},stop:function(){this._i=clearInterval(this._i)},bind:function(){var t=this;r.on("mouseover",e.Html.root,(function(){t._e&&t.stop()})),r.on("mouseout",e.Html.root,(function(){t._e&&t.start()}))},unbind:function(){r.off(["mouseover","mouseout"],e.Html.root)}};return w(i,"time",{get:function(){var n=e.Html.slides[t.index].getAttribute("data-glide-autoplay");return h(n||t.settings.autoplay)}}),n.on(["destroy","update"],(function(){i.unbind()})),n.on(["run.before","swipe.start","update"],(function(){i.stop()})),n.on(["pause","destroy"],(function(){i.disable(),i.stop()})),n.on(["run.after","swipe.end"],(function(){i.start()})),n.on(["play"],(function(){i.enable(),i.start()})),n.on("update",(function(){i.mount()})),n.on("destroy",(function(){r.destroy()})),i},Breakpoints:function(t,e,n){var r=new H,i=t.settings,o=X(i.breakpoints),s=Object.assign({},i),a={match:function(t){if("undefined"!==typeof window.matchMedia)for(var e in t)if(t.hasOwnProperty(e)&&window.matchMedia("(max-width: ".concat(e,"px)")).matches)return t[e];return s}};return Object.assign(i,a.match(o)),r.on("resize",window,S((function(){t.settings=x(i,a.match(o))}),t.settings.throttle)),n.on("update",(function(){o=X(o),s=Object.assign({},i)})),n.on("destroy",(function(){r.off("resize",window)})),a}},$=function(t){!function(t,e){if("function"!==typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function");t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,writable:!0,configurable:!0}}),e&&u(t,e)}(n,t);var e=l(n);function n(){return i(this,n),e.apply(this,arguments)}return s(n,[{key:"mount",value:function(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{};return f(a(n.prototype),"mount",this).call(this,Object.assign({},K,t))}}]),n}(_)},3352:function(t,e,n){"use strict";n.d(e,{O:function(){return K}});var r=n(9472),i=n(678),o=n(3738),s=n(1303),a=n(6222),u=n(8489),c=n(2791),l=n(5612),f=n(7003),d=n(9904),v=n(7369),h=n(981),p=n(4705),m=n(4159),g=n(4381),b=n(2806),y=n(3402);function w(t){var e=t.onFocus,n=(0,c.useState)(!0),r=(0,i.Z)(n,2),o=r[0],s=r[1];return o?c.createElement(y._,{as:"button",type:"button",features:y.A.Focusable,onFocus:function(t){t.preventDefault();var n,r=50;n=requestAnimationFrame((function t(){if(!(r--<=0))return e()?(s(!1),void cancelAnimationFrame(n)):void(n=requestAnimationFrame(t));n&&cancelAnimationFrame(n)}))}}):null}var x=n(3654),T=n(8106),_=n(5718),k=c.createContext(null);function S(t){var e=t.children,n=c.useRef({groups:new Map,get:function(t,e){var n,r=this.groups.get(t);r||(r=new Map,this.groups.set(t,r));var i=null!=(n=r.get(e))?n:0;return r.set(e,i+1),[Array.from(r.keys()).indexOf(e),function(){var t=r.get(e);t>1?r.set(e,t-1):r.delete(e)}]}});return c.createElement(k.Provider,{value:n},e)}function O(t){var e=c.useContext(k);if(!e)throw new Error("You must wrap your component in a <StableCollection>");var n=function(){var t,e,n,r=null!=(n=null==(e=null==(t=c.__SECRET_INTERNALS_DO_NOT_USE_OR_YOU_WILL_BE_FIRED)?void 0:t.ReactCurrentOwner)?void 0:e.current)?n:null;if(!r)return Symbol();for(var i=[],o=r;o;)i.push(o.index),o=o.return;return"$."+i.join(".")}(),r=e.current.get(t,n),o=(0,i.Z)(r,2),s=o[0],a=o[1];return c.useEffect((function(){return a}),[]),s}var E,A,P,R,H=["defaultIndex","vertical","manual","onChange","selectedIndex"],I=["id"],C=["id","tabIndex"],j=((R=j||{})[R.Forwards=0]="Forwards",R[R.Backwards=1]="Backwards",R),z=((P=z||{})[P.Less=-1]="Less",P[P.Equal=0]="Equal",P[P.Greater=1]="Greater",P),M=((A=M||{})[A.SetSelectedIndex=0]="SetSelectedIndex",A[A.RegisterTab=1]="RegisterTab",A[A.UnregisterTab=2]="UnregisterTab",A[A.RegisterPanel=3]="RegisterPanel",A[A.UnregisterPanel=4]="UnregisterPanel",A),Z=(E={},(0,a.Z)(E,0,(function(t,e){var n,r=(0,h.z2)(t.tabs,(function(t){return t.current})),i=(0,h.z2)(t.panels,(function(t){return t.current})),o=r.filter((function(t){var e;return!(null!=(e=t.current)&&e.hasAttribute("disabled"))})),c=(0,u.Z)((0,u.Z)({},t),{},{tabs:r,panels:i});if(e.index<0||e.index>r.length-1){var l,f,v=(0,d.E)(Math.sign(e.index-t.selectedIndex),(l={},(0,a.Z)(l,-1,(function(){return 1})),(0,a.Z)(l,0,(function(){var t;return(0,d.E)(Math.sign(e.index),(t={},(0,a.Z)(t,-1,(function(){return 0})),(0,a.Z)(t,0,(function(){return 0})),(0,a.Z)(t,1,(function(){return 1})),t))})),(0,a.Z)(l,1,(function(){return 0})),l));return 0===o.length?c:(0,u.Z)((0,u.Z)({},c),{},{selectedIndex:(0,d.E)(v,(f={},(0,a.Z)(f,0,(function(){return r.indexOf(o[0])})),(0,a.Z)(f,1,(function(){return r.indexOf(o[o.length-1])})),f))})}var p=r.slice(0,e.index),m=[].concat((0,s.Z)(r.slice(e.index)),(0,s.Z)(p)).find((function(t){return o.includes(t)}));if(!m)return c;var g=null!=(n=r.indexOf(m))?n:t.selectedIndex;return-1===g&&(g=t.selectedIndex),(0,u.Z)((0,u.Z)({},c),{},{selectedIndex:g})})),(0,a.Z)(E,1,(function(t,e){var n;if(t.tabs.includes(e.tab))return t;var r=t.tabs[t.selectedIndex],i=(0,h.z2)([].concat((0,s.Z)(t.tabs),[e.tab]),(function(t){return t.current})),o=null!=(n=i.indexOf(r))?n:t.selectedIndex;return-1===o&&(o=t.selectedIndex),(0,u.Z)((0,u.Z)({},t),{},{tabs:i,selectedIndex:o})})),(0,a.Z)(E,2,(function(t,e){return(0,u.Z)((0,u.Z)({},t),{},{tabs:t.tabs.filter((function(t){return t!==e.tab}))})})),(0,a.Z)(E,3,(function(t,e){return t.panels.includes(e.panel)?t:(0,u.Z)((0,u.Z)({},t),{},{panels:(0,h.z2)([].concat((0,s.Z)(t.panels),[e.panel]),(function(t){return t.current}))})})),(0,a.Z)(E,4,(function(t,e){return(0,u.Z)((0,u.Z)({},t),{},{panels:t.panels.filter((function(t){return t!==e.panel}))})})),E),L=(0,c.createContext)(null);function D(t){var e=(0,c.useContext)(L);if(null===e){var n=new Error("<".concat(t," /> is missing a parent <Tab.Group /> component."));throw Error.captureStackTrace&&Error.captureStackTrace(n,D),n}return e}L.displayName="TabsDataContext";var B=(0,c.createContext)(null);function F(t){var e=(0,c.useContext)(B);if(null===e){var n=new Error("<".concat(t," /> is missing a parent <Tab.Group /> component."));throw Error.captureStackTrace&&Error.captureStackTrace(n,F),n}return e}function W(t,e){return(0,d.E)(e.type,Z,t,e)}B.displayName="TabsActionsContext";var V=c.Fragment;var q=l.AN.RenderStrategy|l.AN.Static;var N=(0,l.yV)((function(t,e){var n,r,i=(0,f.M)(),s=t.id,a=void 0===s?"headlessui-tabs-tab-".concat(i):s,u=(0,o.Z)(t,I),b=D("Tab"),y=b.orientation,w=b.activation,k=b.selectedIndex,S=b.tabs,E=b.panels,A=F("Tab"),P=D("Tab"),R=(0,c.useRef)(null),H=(0,m.T)(R,e);(0,p.e)((function(){return A.registerTab(R)}),[A,R]);var C=O("tabs"),j=S.indexOf(R);-1===j&&(j=C);var z=j===k,M=(0,x.z)((function(t){var e,n=t();if(n===h.fE.Success&&"auto"===w){var r=null==(e=(0,_.r)(R))?void 0:e.activeElement,i=P.tabs.findIndex((function(t){return t.current===r}));-1!==i&&A.change(i)}return n})),Z=(0,x.z)((function(t){var e=S.map((function(t){return t.current})).filter(Boolean);if(t.key===v.R.Space||t.key===v.R.Enter)return t.preventDefault(),t.stopPropagation(),void A.change(j);switch(t.key){case v.R.Home:case v.R.PageUp:return t.preventDefault(),t.stopPropagation(),M((function(){return(0,h.jA)(e,h.TO.First)}));case v.R.End:case v.R.PageDown:return t.preventDefault(),t.stopPropagation(),M((function(){return(0,h.jA)(e,h.TO.Last)}))}return M((function(){return(0,d.E)(y,{vertical:function(){return t.key===v.R.ArrowUp?(0,h.jA)(e,h.TO.Previous|h.TO.WrapAround):t.key===v.R.ArrowDown?(0,h.jA)(e,h.TO.Next|h.TO.WrapAround):h.fE.Error},horizontal:function(){return t.key===v.R.ArrowLeft?(0,h.jA)(e,h.TO.Previous|h.TO.WrapAround):t.key===v.R.ArrowRight?(0,h.jA)(e,h.TO.Next|h.TO.WrapAround):h.fE.Error}})}))===h.fE.Success?t.preventDefault():void 0})),L=(0,c.useRef)(!1),B=(0,x.z)((function(){var t;L.current||(L.current=!0,null==(t=R.current)||t.focus(),A.change(j),(0,T.Y)((function(){L.current=!1})))})),W=(0,x.z)((function(t){t.preventDefault()})),V=(0,c.useMemo)((function(){return{selected:z}}),[z]),q={ref:H,onKeyDown:Z,onMouseDown:W,onClick:B,id:a,role:"tab",type:(0,g.f)(t,R),"aria-controls":null==(r=null==(n=E[j])?void 0:n.current)?void 0:r.id,"aria-selected":z,tabIndex:z?0:-1};return(0,l.sY)({ourProps:q,theirProps:u,slot:V,defaultTag:"button",name:"Tabs.Tab"})})),G=(0,l.yV)((function(t,e){var n=t.defaultIndex,s=void 0===n?0:n,a=t.vertical,f=void 0!==a&&a,d=t.manual,v=void 0!==d&&d,g=t.onChange,y=t.selectedIndex,T=void 0===y?null:y,_=(0,o.Z)(t,H),k=f?"vertical":"horizontal",O=v?"manual":"auto",E=null!==T,A=(0,m.T)(e),P=(0,c.useReducer)(W,{selectedIndex:null!=T?T:s,tabs:[],panels:[]}),R=(0,i.Z)(P,2),I=R[0],C=R[1],j=(0,c.useMemo)((function(){return{selectedIndex:I.selectedIndex}}),[I.selectedIndex]),z=(0,b.E)(g||function(){}),M=(0,b.E)(I.tabs),Z=(0,c.useMemo)((function(){return(0,u.Z)({orientation:k,activation:O},I)}),[k,O,I]),D=(0,x.z)((function(t){return C({type:1,tab:t}),function(){return C({type:2,tab:t})}})),F=(0,x.z)((function(t){return C({type:3,panel:t}),function(){return C({type:4,panel:t})}})),q=(0,x.z)((function(t){N.current!==t&&z.current(t),E||C({type:0,index:t})})),N=(0,b.E)(E?t.selectedIndex:I.selectedIndex),G=(0,c.useMemo)((function(){return{registerTab:D,registerPanel:F,change:q}}),[]);(0,p.e)((function(){C({type:0,index:null!=T?T:s})}),[T]),(0,p.e)((function(){if(!(void 0===N.current||I.tabs.length<=0)){var t=(0,h.z2)(I.tabs,(function(t){return t.current}));t.some((function(t,e){return I.tabs[e]!==t}))&&q(t.indexOf(I.tabs[N.current]))}}));var Y={ref:A};return c.createElement(S,null,c.createElement(B.Provider,{value:G},c.createElement(L.Provider,{value:Z},Z.tabs.length<=0&&c.createElement(w,{onFocus:function(){var t,e,n,i=(0,r.Z)(M.current);try{for(i.s();!(n=i.n()).done;){var o=n.value;if(0===(null==(t=o.current)?void 0:t.tabIndex))return null==(e=o.current)||e.focus(),!0}}catch(s){i.e(s)}finally{i.f()}return!1}}),(0,l.sY)({ourProps:Y,theirProps:_,slot:j,defaultTag:V,name:"Tabs"}))))})),Y=(0,l.yV)((function(t,e){var n=D("Tab.List"),r=n.orientation,i=n.selectedIndex,o=(0,m.T)(e);return(0,l.sY)({ourProps:{ref:o,role:"tablist","aria-orientation":r},theirProps:t,slot:{selectedIndex:i},defaultTag:"div",name:"Tabs.List"})})),U=(0,l.yV)((function(t,e){var n=D("Tab.Panels").selectedIndex,r=(0,m.T)(e),i=(0,c.useMemo)((function(){return{selectedIndex:n}}),[n]);return(0,l.sY)({ourProps:{ref:r},theirProps:t,slot:i,defaultTag:"div",name:"Tabs.Panels"})})),X=(0,l.yV)((function(t,e){var n,r,i,s,a=(0,f.M)(),d=t.id,v=void 0===d?"headlessui-tabs-panel-".concat(a):d,h=t.tabIndex,g=void 0===h?0:h,b=(0,o.Z)(t,C),w=D("Tab.Panel"),x=w.selectedIndex,T=w.tabs,_=w.panels,k=F("Tab.Panel"),S=(0,c.useRef)(null),E=(0,m.T)(S,e);(0,p.e)((function(){return k.registerPanel(S)}),[k,S]);var A=O("panels"),P=_.indexOf(S);-1===P&&(P=A);var R=P===x,H=(0,c.useMemo)((function(){return{selected:R}}),[R]),I={ref:E,id:v,role:"tabpanel","aria-labelledby":null==(r=null==(n=T[P])?void 0:n.current)?void 0:r.id,tabIndex:R?g:-1};return R||null!=(i=b.unmount)&&!i||null!=(s=b.static)&&s?(0,l.sY)({ourProps:I,theirProps:b,slot:H,defaultTag:"div",features:q,visible:R,name:"Tabs.Panel"}):c.createElement(y._,(0,u.Z)({as:"span"},I))})),K=Object.assign(N,{Group:G,List:Y,Panels:U,Panel:X})}}]);
//# sourceMappingURL=105.db09d5d7.chunk.js.map